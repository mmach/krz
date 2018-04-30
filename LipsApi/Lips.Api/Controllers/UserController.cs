using Lips.Api.Model;
using Lips.Api.Users;
using Lips.Dto.Users;
using Lips.Service.Users;
using Lips.Tool.MailHelper;
using Lips.Tool.Parser;
using Lips.Tool.QRCode;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class UserController : BaseController
    {
        IUserService _userServcice { set; get; }
        IRegisterUserService _registerUserService { get; set; }
        IInstitutionService _institutionService { set; get; }

        public UserController(IUserService userService, IRegisterUserService registerUserService, InstitutionService institutionService)
        {
            _userServcice = userService;
            _registerUserService = registerUserService;
            _institutionService = institutionService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> SendMailToAll()
        {
            var user = _userServcice.Get(2);
            string modelXml = "";
            XmlSerializator.XmlSerialize(user, ref modelXml);
            QRCoderGenerator.GenerateSave(user.Guid.ToString(), $"{user.ExternalClientId}${user.BirthDate}");
            var xslt = Convert.ToString(Lips.Tool.Properties.Resources.ActivateNewUser);
            if (MailSend.SendMail(modelXml, xslt, ConfigurationManager.AppSettings["mail"], $"Activate User -  {user.Name}"))
            {
                return Ok();
            }
            return BadRequest();
        }





        [HttpPost]
        [Authorize]
        public async Task<IHttpActionResult> ContactRequest(ContactRequestObject contact)
        {
            var user = _userServcice.GetUserDetail(this.userid);

            contact.Address = user.Address;
            contact.Institution = user.Institution.Address;
            contact.NameAuth = user.Name;
            contact.ClientId = user.ExternalClientId;
            string modelXml = "";
            XmlSerializator.XmlSerialize(contact, ref modelXml);
            string xslt = Convert.ToString(Lips.Tool.Properties.Resources.ContactRequestLips);

            if (MailSend.SendMail(modelXml, xslt, ConfigurationManager.AppSettings["mail"], $"Contact aanvraag  door  {contact.Name} voor {contact.NameAuth}, {contact.Institution}"))
            {
                xslt = Convert.ToString(Lips.Tool.Properties.Resources.ContactRequestClient);
                if (MailSend.SendMail(modelXml, xslt, user.Email, $"Contact aanvraag  door  { contact.Name} voor { contact.NameAuth}, { contact.Institution}"))
                {
                    return Ok();
                }
            };
            return BadRequest();
        }


       

        [HttpPost]
        public async Task<IHttpActionResult> NewQRCodeRequest(NewQRCodeObject model)
        {
            var userSh = _userServcice.GetByGuid(Convert.ToInt64(model.ClientReferenceCode));

            if (getNewQrClient(userSh.Id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public async Task<IHttpActionResult> NewQRCodeRequestAuth()
        {
            if (getNewQrClient(this.userid))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetUserInfo()
        {
            return Ok(_userServcice.Get(this.userid));
        }
        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetUserDetail()
        {
            return Ok(_userServcice.GetUserDetail(this.userid));
        }
        [HttpGet]
        public async Task<IHttpActionResult> RefreshToken(string token)
        {
            try
            {
                UserDto user = _userServcice.GetByToken(token);
                var tokenExpiration = TimeSpan.FromDays(1);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.ExternalClientId)));
                claims.Add(new Claim(ClaimTypes.Sid, Convert.ToString(user.Id)));
                claims.Add(new Claim(ClaimTypes.Name, user.Name));
                //claims.Add(new Claim(ClaimTypes.Surname, result.FirstItem.Surname));
                //claims.Add(new Claim(ClaimTypes.Email, context.UserName));

                ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);

                identity.AddClaims(claims);

                var props = new AuthenticationProperties()
                {
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
                };

                var ticket = new AuthenticationTicket(identity, props);

                var accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);

                JObject tokenResponse = new JObject(
                                            new JProperty("userName", userName),
                                            new JProperty("access_token", accessToken),
                                            new JProperty("token_type", "bearer"),
                                            new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                            new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                            new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
                );

                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> UserRegister([FromBody]UserRegisterObject user)
        {
            if (ModelState.IsValid)
            {
                var controllerResult = new PaymentController((RegisterUserService)_registerUserService, (InstitutionService)_institutionService);
                var modelDto = new RegisterUserDto
                {
                    BankId = user.BankID,
                    City = user.City,
                    Email = user.Email,
                    Gender = (int)user.Gender,
                    HouseNumber = user.HouseNumber,
                    InstitutionHouseNumber = user.InstitutionHouseNumber,
                    InstitutionId = user.InstitutionId,
                    Name = user.Name,
                    Phone = user.PhoneNumber,
                    PostCode = user.Postcode,
                    Street = user.Street,
                    Guid = Guid.NewGuid().ToString(),
                    ModifiedDate = DateTime.Now,
                    PaymentStatus = PaymentStatusEnumDto.New,
                    DateOfBirth = DateTime.ParseExact(user.DateOfBirth, "dd-MM-yyyy", null)
                };
                var registeredUser = _registerUserService.Create(modelDto);
                string modelXml = "";
                  XmlSerializator.XmlSerialize(modelDto, ref modelXml);
            

                var tmp = await controllerResult.CreateMandate(user.BankID, registeredUser);

                var xslt = Convert.ToString(Lips.Tool.Properties.Resources.PaymentPendingClient);
                if (MailSend.SendMail(modelXml, xslt, user.Email, "In afwachting van uw betaling"))
                {

                    return Ok(
                        controllerResult.CreateMandateResult
                    );
                }
               

            }
            return BadRequest(ModelState);

        }

        private bool getNewQrClient(long userid)
        {
            var user = _userServcice.GetUserDetail(userid);
            string modelXml = "";
            XmlSerializator.XmlSerialize(user, ref modelXml);
            QRCoderGenerator.GenerateSave(user.Guid.ToString(), $"{user.ExternalClientId}${user.BirthDate}");
            string xslt = Convert.ToString(Lips.Tool.Properties.Resources.NewQRCodeLipsClient);
            if (MailSend.SendMail(modelXml, xslt, user.Email, $"Aanvraag QR code door {user.Name}, {user.Institution.Address}"))
            {
                xslt = Convert.ToString(Lips.Tool.Properties.Resources.NewQRCodeLips);

                if (MailSend.SendMail(modelXml, xslt, ConfigurationManager.AppSettings["mail"], $"Aanvraag QR code door {user.Name}, {user.Institution.Address}"))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

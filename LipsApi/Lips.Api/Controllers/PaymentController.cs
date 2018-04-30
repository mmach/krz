using BuckarooSdk;
using BuckarooSdk.Data;
using BuckarooSdk.DataTypes.RequestBases;
using BuckarooSdk.Services;
using Lips.Api.Model;
using Lips.Dto.Users;
using Lips.Service.Users;
using Lips.Tool.MailHelper;
using Lips.Tool.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class PaymentController : ApiController
    {
        private SdkClient BuckarooClient { get; set; }

        private string key { get { return ConfigurationManager.AppSettings["mandateKey"]; } }

        private string apiBaseAddress { get { return ConfigurationManager.AppSettings["mandateUrl"]; } }
        private string website { get { return ConfigurationManager.AppSettings["mandateClient"]; } }
        private string amount { get { return ConfigurationManager.AppSettings["mandateMaxAmount"]; } }
        public object CreateMandateResult { set; get; }
        IRegisterUserService _registerUser { get; set; }
        IInstitutionService _institutionService { set; get; }
        public PaymentController(RegisterUserService registerUserService, InstitutionService institutionService)
        {
            BuckarooClient = new SdkClient();
            _registerUser = registerUserService;
            _institutionService = institutionService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBanks()
        {

            CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();
            HttpClient client = HttpClientFactory.Create(customDelegatingHandler);

            // var bodyString = "{\"Services\": {\"ServiceList\": [{\"Name\": \"emandate\",\"Action\": \"GetIssuerList\"}]}}";
            //object body = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(bodyString);
            ServicesRoot body = new ServicesRoot();
            body.Services = new ServicesObject();
            body.Services.ServiceList = new List<ServiceList>()
            {
                new ServiceList()
                {
                    Name = "emandate",
                    Action = "GetIssuerList"
                }
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(apiBaseAddress, body);
            var result = response.Content.ReadAsStringAsync().Result;

            var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ServicesObject>(result);

            return Ok(resultObject.Services.FirstOrDefault().Parameters);
        }

        [HttpGet]
        public async Task<IHttpActionResult> UpdateStatus(long userID, string mandateId)
        {

            CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();
            HttpClient client = HttpClientFactory.Create(customDelegatingHandler);


            ServicesRoot body = new ServicesRoot();
            body.Services = new ServicesObject();
            body.Services.ServiceList = new List<ServiceList>()
            {
                new ServiceList()
                {
                    Name = "emandate",
                    Action = "GetStatus",
                    Parameters = new List<ParameterObject>()
                    {
                        new ParameterObject()
                        {
                            Name="mandateid",
                            Value=mandateId
                        }
                    }
                }
            };
            var user = _registerUser.Get(userID);
            if (user.IsMailSend)
            {
                return BadRequest("Mail was send");
            }

            HttpResponseMessage response = await client.PostAsJsonAsync(apiBaseAddress, body);
            var result = response.Content.ReadAsStringAsync().Result;

            if (user.MandateId == mandateId)
            {
                var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ServicesObject>(result);
                PaymentStatusEnumDto enumStatus;
                if (Enum.TryParse(resultObject.Services.FirstOrDefault().Parameters.Where(m => { return m.Name == "EmandateStatus"; }).FirstOrDefault().Value, out enumStatus))
                {
                    string IBAN = resultObject.Services.FirstOrDefault().Parameters.Where(m => { return m.Name == "Iban"; })?.FirstOrDefault()?.Value;
                    user.IBAN = IBAN;
                    user.Amount = resultObject.Services.FirstOrDefault().Parameters.Where(m => { return m.Name == "MaxAmount"; })?.FirstOrDefault()?.Value;
                    string modelXml = "";

                    XmlSerializator.XmlSerialize(user, ref modelXml);

                    string xslt = Convert.ToString(Lips.Tool.Properties.Resources.PaymentNewClient);

                    MailSend.SendMail(modelXml, xslt, user.Email, "WasApp " + user.Name + " - New user");

                    xslt = Convert.ToString(Lips.Tool.Properties.Resources.PaymentLastStatusClient);
                    if (enumStatus == PaymentStatusEnumDto.Success)
                    {
                       
                        MailSend.SendMail(modelXml, xslt, user.Email, "Ontvangstbevestiging van uw betaling");
                        xslt = Convert.ToString(Lips.Tool.Properties.Resources.PaymentNewClientLips);

                        if (MailSend.SendMail(modelXml, xslt, ConfigurationManager.AppSettings["mail"], $"Automatische incasso {user.Name}, {user.InstitutionId}"))
                        {
                            user.IsMailSend = true;
                        }

                    }
                 //   else if (enumStatus == PaymentStatusEnumDto.Failure)
                 //   {
                 //       MailSend.SendMail(modelXml, xslt, user.Email, "WasApp " + user.Name + "- payment " + user.MandateId + " failured");
                 //   }
                 //   else if (enumStatus == PaymentStatusEnumDto.Failure)
                 //   {
                 //       MailSend.SendMail(modelXml, xslt, user.Email, "WasApp " + user.Name + "- payment " + user.MandateId + " cancelled");
                 //   }

                    user.PaymentStatus = enumStatus;
                    _registerUser.Update(user);
                    return Ok(resultObject.Services.FirstOrDefault().Parameters.Where(m => { return m.Name == "EmandateStatus"; }));
                }
                else
                {
                    return BadRequest("Wrong Payment status");
                }

            }
            else
            {
                return BadRequest("Wrong MandateID");
            }


        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateMandate(string bank, RegisterUserDto user)
        {

            CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler();
            HttpClient client = HttpClientFactory.Create(customDelegatingHandler);

            // var bodyString = "{\"Services\": {\"ServiceList\": [{\"Name\": \"emandate\",\"Action\": \"GetIssuerList\"}]}}";
            //object body = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(bodyString);
            ServicesRoot body = new ServicesRoot();
            body.Currency = "EUR";
            body.Services = new ServicesObject();
            body.Services.ServiceList = new List<ServiceList>()
            {
                new ServiceList()
                {
                    Name = "emandate",
                    Action = "CreateMandate",
                    Parameters= new List<ParameterObject>
                    {
                        new ParameterObject()
                        {
                            Name="emandatereason",
                            Value="testing"
                        },
                        new ParameterObject()
                        {
                            Name="sequencetype",
                            Value="1"
                        },
                        new ParameterObject()
                        {
                            Name="purchaseid",
                            Value = "purchaseid1234"
                        },
                        new ParameterObject()
                        {
                            Name="debtorbankid",
                            Value=bank
                        },
                        new ParameterObject()
                        {
                            Name="debtorreference",
                            Value= "klant1234"
                        },
                        new ParameterObject()
                        {
                            Name="language",
                            Value ="nl"
                        },
                      //   new ParameterObject()
                      //  {
                      //      Name="maxamount",
                      //      Value =amount
                      //  }

                    }
                }
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(apiBaseAddress, body);
            var result = response.Content.ReadAsStringAsync().Result;

            var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ServicesObject>(result);
            CreateMandateResult = new
            {
                Redirect = resultObject.RequiredAction.RedirectURL,
                EmandateId = resultObject.Services.FirstOrDefault().Parameters.FirstOrDefault().Value,
                User = user.Id
            };

            user.MandateId = resultObject.Services.FirstOrDefault().Parameters.FirstOrDefault().Value;
            user.PaymentStatus = PaymentStatusEnumDto.Pending;
            _registerUser.UpdateByGuid(user);

            return Ok(CreateMandateResult);
        }
    }




    public class CustomDelegatingHandler : DelegatingHandler
    {
        //Obtained from the server earlier
        private string WebsiteKey { get { return ConfigurationManager.AppSettings["mandateClient"]; } }
        private string SecretKey { get { return ConfigurationManager.AppSettings["mandateKey"]; } }


        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            string requestContentBase64String = string.Empty;

            string requestUri = System.Web.HttpUtility.UrlEncode(request.RequestUri.Authority + request.RequestUri.PathAndQuery).ToLower();

            string requestHttpMethod = request.Method.Method;

            // calculate UNIX time
            DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = DateTime.UtcNow - epochStart;
            string requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

            // create random nonce for each request
            string nonce = Guid.NewGuid().ToString("N");

            // checking if the request contains body, usually will be null with HTTP GET and DELETE
            if (request.Content != null)
            {
                byte[] content = await request.Content.ReadAsByteArrayAsync();
                MD5 md5 = MD5.Create();

                // hashing the request body, any change in request body will result in different hash, we'll incure message integrity
                byte[] requestContentHash = md5.ComputeHash(content);
                requestContentBase64String = Convert.ToBase64String(requestContentHash);
            }

            // creating the raw signature string
            string signatureRawData = String.Format("{0}{1}{2}{3}{4}{5}", WebsiteKey, requestHttpMethod, requestUri, requestTimeStamp, nonce, requestContentBase64String);

            var secretKeyByteArray = Encoding.UTF8.GetBytes(SecretKey);

            byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                string requestSignatureBase64String = Convert.ToBase64String(signatureBytes);

                // setting the values in the Authorization header using custom scheme (hmac)
                request.Headers.Authorization = new AuthenticationHeaderValue("hmac", string.Format("{0}:{1}:{2}:{3}", WebsiteKey, requestSignatureBase64String, nonce, requestTimeStamp));
            }

            // set other headers
            request.Headers.Add("culture", "nl-NL");
            request.Headers.Add("channel", "Web");

            response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}

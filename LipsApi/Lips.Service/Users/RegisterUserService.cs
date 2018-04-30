using Lips.Domain.Users;
using Lips.Dto.Users;
using Lips.Repository;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Users
{
    public class RegisterUserService : BaseService<RegisterUserDto, RegisterUser>, IRegisterUserService
    {
        public RegisterUserService(IBaseRepository<RegisterUser> repository) : base(repository)
        {

        }

        public RegisterUserDto UpdateByGuid(RegisterUserDto registerUser)
        {
            var domain = Repository.Where(p => p.Guid == registerUser.Guid).First();
            return DoUpdate(domain, registerUser);
        }

        public RegisterUserDto UpdateById(RegisterUserDto registerUser)
        {
            var domain = Repository.Where(p => p.Id == registerUser.Id).First();
            return DoUpdate(domain, registerUser);
        }

        public RegisterUserDto UpdateByMandateId(RegisterUserDto registerUser)
        {
            var domain = Repository.Where(p => p.MandateId == registerUser.MandateId).First();
            return DoUpdate(domain, registerUser);
        }

        RegisterUserDto DoUpdate(RegisterUser domain, RegisterUserDto dto)
        {

            domain.BankId = dto.BankId;
            domain.City = dto.City;
            domain.Email = dto.Email;
            domain.Gender = dto.Gender;
            domain.HouseNumber = dto.HouseNumber;
            domain.InstitutionHouseNumber = dto.InstitutionHouseNumber;
            domain.InstitutionId = dto.InstitutionId;
            domain.MandateId = dto.MandateId;
            domain.ModifiedDate = DateTime.Now;
            domain.Name = dto.Name;
            domain.PaymentStatus = (PaymentStatusEnum)(int)dto.PaymentStatus;
            domain.Phone = dto.Phone;
            domain.PostCode = dto.PostCode;
            domain.Street = dto.Street;

            Repository.SaveChanges();

            return dto;
        }

    }
}

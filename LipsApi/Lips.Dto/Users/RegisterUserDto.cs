using Lips.Dto.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Users
{
    public class RegisterUserDto :BaseDto
    {
        public string City { get; set; }
        public int Gender { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string InstitutionHouseNumber { get; set; }
        public string InstitutionId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PostCode { get; set; }
        public string BankId { get; set; }
        public string MandateId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public PaymentStatusEnumDto PaymentStatus { get; set; }
        public DateTime DateOfBirth { set; get; }
        public bool IsMailSend { set; get; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string Amount { set; get; }
        public string IBAN { set; get; }
    }
}

using Lips.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Users
{
    public class RegisterUser : Base
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
        public PaymentStatusEnum PaymentStatus { get; set; }
        public DateTime DateOfBirth { set; get; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public bool IsMailSend { set; get; }
        public string Amount { set; get; }
        public string IBAN { set; get; }
    }
}

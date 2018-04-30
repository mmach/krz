using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Api.Users
{
    public class UserRegisterObject
    {
        [Required]
        public string City { get; set; }

        public string Email { get; set; }

        public GenderEnum Gender { get; set; }
        //[Required]
        public string HouseNumber { get; set; }
        [Required]
        public string Street { get; set; }

        [Required]
        public string InstitutionHouseNumber { get; set; }

        [Required]
        public string InstitutionId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Postcode { get; set; }
   
        [Required]
        public string DateOfBirth { set; get; }

        public string BankID { get; set; }
    }

}

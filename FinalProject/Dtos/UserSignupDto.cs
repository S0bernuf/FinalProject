using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BusinessLogic.CustomAttributes;
using Microsoft.AspNetCore.Http;

namespace FinalProject.BusinessLogic.Dtos
{
    public class UserSignupDto
    {
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 12)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,}$", ErrorMessage = "Password must meet complexity requirements.")]
        public string Password { get; set; }

        [Required]
        [Name(ErrorMessage = "Invalid name.")]
        public string FirstName { get; set; }

        [Required]
        [LastName(ErrorMessage = "Invalid last name.")]
        public string LastName { get; set; }

        [Required]
        [Gender(ErrorMessage = "Invalid gender.")]
        public string Gender { get; set; }

        [Required]
        [Birthday(ErrorMessage = "Invalid birthday.")]
        public DateTime Birthday { get; set; }

        [Required]
        [PersonalId(ErrorMessage = "Invalid personal identification code.")]
        public string PersonalCode { get; set; }

        [Required]
        [PhoneNumber(ErrorMessage = "Invalid telephone number.")]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailDomain(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }

        [Required]
        public IFormFile ProfilePhoto { get; set; }

        [Required]
        public AddressDto PlaceOfResidence { get; set; }
    }

}

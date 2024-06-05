using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 12)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{12,}$", ErrorMessage = "Password must meet complexity requirements.")]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name can only contain letters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name can only contain letters.")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Personal Code must be alphanumeric and unique.")]
        public string PersonalCode { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Telephone Number must follow E.164 format.")]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IFormFile ProfilePhoto { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City cannot contain numbers or special characters.")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^.*\s.*$", ErrorMessage = "Street must contain at least one space.")]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[A-Za-z]?$", ErrorMessage = "House Number must be alphanumeric.")]
        public string HouseNumber { get; set; }

        public string ApartmentNumber { get; set; }
    }
}

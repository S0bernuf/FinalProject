using FinalProject.BusinessLogic.CustomAttributes;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.BusinessLogic.Dtos
{
    public class PersonDto
    {
        [Required]
        [Name]
        public string FirstName { get; set; }

        [Required]
        [LastName]
        public string LastName { get; set; }

        [Required]
        [Gender]
        public string Gender { get; set; }

        [Required]
        [Birthday]
        public DateOnly Birthday { get; set; }

        [Required]
        [PersonalId]
        public string PersonalCode { get; set; }

        [Required]
        [PhoneNumber]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailDomain]
        public string Email { get; set; }

        public AddressDto AddressDto { get; set; }
    }
}

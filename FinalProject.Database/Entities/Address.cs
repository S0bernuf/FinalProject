using System.ComponentModel.DataAnnotations;


namespace FinalProject.Database.Entities
{

    public class Address
    {
        [Key]
        public int AddressId { get; set; }

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

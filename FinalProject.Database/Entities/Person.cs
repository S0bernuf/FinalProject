﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinalProject.Database.Entities
{

    public class Person
    {
        [Key]
        public int PersonId { get; set; }

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
        public DateOnly Birthday { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]+$", ErrorMessage = "Personal Code must be alphanumeric and unique.")]
        public string PersonalCode { get; set; }

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Telephone Number must follow E.164 format.")]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}

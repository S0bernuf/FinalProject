﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Entities
{
    public class Residence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City cannot contain numbers or special characters.")]
        //[CityAttribute(ErrorMessage = "Invalid city name.")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^.*\s.*$", ErrorMessage = "Street must contain at least one space.")]
        public string Street { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+[A-Za-z]?$", ErrorMessage = "House Number must be alphanumeric.")]
        public string HouseNumber { get; set; }

        public string ApartmentNumber { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

    }
}

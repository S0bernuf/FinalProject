using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BusinessLogic.CustomAttributes;

namespace FinalProject.BusinessLogic.Dtos
{
    public class AddressDto
    {
        [Required]
        [City(ErrorMessage = "Invalid city name.")]
        public string City { get; set; }

        [Required]
        [Street(ErrorMessage = "Invalid street name.")]
        public string Street { get; set; }

        [Required]
        [HouseNumber(ErrorMessage = "Invalid house number.")]
        public string HouseNumber { get; set; }

        [ApartmentNumber(ErrorMessage = "Invalid apartment number.")]
        public string ApartmentNumber { get; set; }
    }
}

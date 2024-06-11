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
        [City]
        public string City { get; set; }

        [Required]
        [Street]
        public string Street { get; set; }

        [Required]
        [HouseNumber]
        public string HouseNumber { get; set; }

        [ApartmentNumber]
        public string ApartmentNumber { get; set; }
    }
}

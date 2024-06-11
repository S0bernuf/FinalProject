﻿using FinalProject.BusinessLogic.CustomAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime Birthday { get; set; }

        [Required]
        [PersonalId]
        public string PersonalCode { get; set; }

        [Required]
        [PhoneNumber]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailDomain]
        public string Email { get; set; }

        [Required]
        public IFormFile ProfilePhoto { get; set; }

        [Required]
        public AddressDto PlaceOfResidence { get; set; }
    }
}
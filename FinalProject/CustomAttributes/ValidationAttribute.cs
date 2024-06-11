using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.BusinessLogic.CustomAttributes
{
    // Perdaryti i atskitus ir sulietuvinti jei laiko bus, validacijos generic tokios tai pakeist i tikslesnes
    public class CityAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var city = value as string;
            if (!Regex.IsMatch(city, @"^[a-zA-Z\s]+$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid city name.");
            }
            return ValidationResult.Success;
        }
    }

    public class StreetAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var street = value as string;
            if (!Regex.IsMatch(street, @"^.*\s.*$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid street name.");
            }
            return ValidationResult.Success;
        }
    }

    public class HouseNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var houseNumber = value as string;
            if (!Regex.IsMatch(houseNumber, @"^[0-9]+[A-Za-z]?$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid house number.");
            }
            return ValidationResult.Success;
        }
    }

    public class ApartmentNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var apartmentNumber = value as string;
            if (!string.IsNullOrEmpty(apartmentNumber) && !Regex.IsMatch(apartmentNumber, @"^[0-9]+[A-Za-z]?$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid apartment number.");
            }
            return ValidationResult.Success;
        }
    }

    public class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = value as string;
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid name.");
            }
            return ValidationResult.Success;
        }
    }

    public class LastNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var lastName = value as string;
            if (!Regex.IsMatch(lastName, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid last name.");
            }
            return ValidationResult.Success;
        }
    }

    public class GenderAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var gender = value as string;
            if (!new[] { "Male", "Female" }.Contains(gender))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid gender.");
            }
            return ValidationResult.Success;
        }
    }

    public class BirthdayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var birthday = (DateTime)value;
            if (birthday > DateTime.Now)
            {
                return new ValidationResult(ErrorMessage ?? "Invalid birthday.");
            }
            return ValidationResult.Success;
        }
    }

    public class PersonalIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var personalId = value as string;
            if (!Regex.IsMatch(personalId, @"^[A-Z0-9]+$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid personal identification code.");
            }
            return ValidationResult.Success;
        }
    }

    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = value as string;
            if (!Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$"))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid telephone number.");
            }
            return ValidationResult.Success;
        }
    }

    public class EmailDomainAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;
            if (!new EmailAddressAttribute().IsValid(email))
            {
                return new ValidationResult(ErrorMessage ?? "Invalid email.");
            }
            return ValidationResult.Success;
        }
    }
}

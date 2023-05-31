using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomAnnotationPOC.Models
{
    public class ValidateBirthDate:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _birthDate = Convert.ToDateTime(value);
            DateTime minDate = Convert.ToDateTime("01-01-1990");
            DateTime maxDate = Convert.ToDateTime("01-01-2000");

            if (_birthDate > minDate && _birthDate < maxDate)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
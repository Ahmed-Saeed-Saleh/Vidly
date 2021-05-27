using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyApp.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cust = (Customer)validationContext.ObjectInstance;
            if (cust.MembershipTypeId == 1 || cust.MembershipTypeId == 0)
            {
                return ValidationResult.Success;
            }
            if (cust.BirthDate == null)
            {
                return new ValidationResult("Birthdate is Required");
            }
            var age = DateTime.Today.Year - cust.BirthDate.Value.Year;
            if(age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer Should be at least 18 years old");

        }
    }
}
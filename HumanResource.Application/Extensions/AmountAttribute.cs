using HumanResource.Application.Models.DTOs.ExpenseDTO;
using HumanResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Extensions
{
    public class AmountAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Decimal amount = (Decimal)value;
            if (amount == 0)
            {
                return new ValidationResult("please enter a non-zero (0) value");
            }
            return ValidationResult.Success;
           // return base.IsValid(value, validationContext);
        }
    }
}

using HumanResource.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;


namespace HumanResource.Application.Extensions
{
    public class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Leave izin = value as Leave;
            if(izin.StartDate <= DateTime.Now)
            {
                return new ValidationResult("Bugünden önceki bir tarihten izin alamazsınız");
            }

            //return base.IsValid(value, validationContext);

            return ValidationResult.Success;
        }
    }
}

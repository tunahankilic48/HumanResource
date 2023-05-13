using Bogus.DataSets;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.CompanyVM
{
    public class CompanyDetailsVM
    {
        public int Id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Tax Number")]
        public string TaxNumber { get; set; }

        [Required(ErrorMessage = "TaxOffice name cannot be null.")]
        [Display(Name = "TaxOffice Name")]
        public string TaxOfficeName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Number Of Employee")]
        public string NumberOfEmployee { get; set; }

        [Display(Name = ("City"))]
        public string? City { get; set; }

		[Display(Name = ("District"))]
        public string? District { get; set; }

        [Display(Name = ("Address Description"))]
        public string? AddressDescription { get; set; }

        [Display(Name = "Manager")]
        public AppUser Manager { get; set; }

        [ValidateNever]
        public string? ImagePath { get; set; }
    }
}

﻿using HumanResource.Application.Models.VMs.AddressVM;
using HumanResource.Application.Models.VMs.PersonelVM;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class UpdateProfileDTO
    {

        public Guid Id { get; set; }

        [MinLength(6, ErrorMessage = "User name must be more than 6 characters.")]
        [MaxLength(30, ErrorMessage = "User name must be less than 30 characters.")]
        [Required(ErrorMessage = "User name cannot be null.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [MinLength(6, ErrorMessage = "Password must be more than 6 characters.")]
        [MaxLength(30, ErrorMessage = "Password must be less than 30 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords are not same.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirm")]
        public string? ConfirmPassword { get; set; }


        [Required(ErrorMessage = "E-mail cannot be null.")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Recruitment Date")]
        public DateTime? RecruitmentDate { get; set; }

        [Display(Name = "Birt Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name ="Manager")]
        public string? ManagerName { get; set; }

        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }

        [Display(Name = "Blood Type")]
        public int? BloodTypeId { get; set; }

        [Display(Name =("City"))]
        public int? CityId { get; set; }

        [Display(Name = ("District"))]
        public int? DistrictId { get; set; }

        [Display(Name = ("Address Description"))]
        public string? AddressDescription { get; set; }

        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string? ImagePath { get; set; }

        public DateTime ModifiedDate => DateTime.Now;

        [ValidateNever]
        public string FullName { get; set; }



    }
}

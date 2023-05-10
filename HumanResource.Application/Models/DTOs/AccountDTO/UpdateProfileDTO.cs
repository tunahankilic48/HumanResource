using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.AccountDTO
{
    public class UpdateProfileDTO
    {

        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(30, ErrorMessage = "First name must be less than 30 characters.")]
        [Required(ErrorMessage = "First name cannot be null.")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last name must be less than 50 characters.")]
        [Required(ErrorMessage = "Last name cannot be null.")]
        public string LastName { get; set; }

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

		[MinLength(3, ErrorMessage = "Company name must be more than 3 characters.")]
		[Required(ErrorMessage = "Company name cannot be null.")]
		[Display(Name = "Company Name")]
		public string CompanyName { get; set; }

		[Required(ErrorMessage = "Tax Number cannot be null.")]
		[Display(Name = "Tax Number")]
		public string TaxNumber { get; set; }

		[MinLength(3, ErrorMessage = "TaxOffice name must be more than 3 characters.")]
		[MaxLength(50, ErrorMessage = "TaxOffice name must be less than 50 characters.")]
		[Required(ErrorMessage = "TaxOffice name cannot be null.")]
		[Display(Name = "TaxOffice Name")]
		public string TaxOfficeName { get; set; }

		[Required(ErrorMessage = "Phone cannot be null.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Number Of Employee cannot be null.")]
		[Display(Name = "Number Of Employee")]
		public string NumberOfEmployee { get; set; }

		[Display(Name = ("City"))]
        public int? CityId { get; set; }

        [Display(Name = ("District"))]
        public int? DistrictId { get; set; }

        [Display(Name = ("Address Description"))]
        public string? AddressDescription { get; set; }

        [Display(Name = "Blood Type")]
        public int? BloodTypeId { get; set; }
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }

        [Display(Name = "Birt Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Recruitment Date")]
        public DateTime? RecruitmentDate { get; set; }


        [Display(Name ="Manager")]
        public string? ManagerName { get; set; }

        [Display(Name = "Title")]
        public string? TitleName { get; set; }




        [ValidateNever]
        public IFormFile? Image { get; set; }

        [ValidateNever]
        public string? ImagePath { get; set; }

        public DateTime ModifiedDate => DateTime.Now;

        [ValidateNever]
        public string FullName { get; set; }

        [ValidateNever]
        public string BaseUrl{ get; set; }



    }
}

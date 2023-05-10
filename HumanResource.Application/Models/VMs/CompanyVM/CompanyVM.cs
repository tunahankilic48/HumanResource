using HumanResource.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.CompanyVM
{
    public class CompanyVM
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Title")]
        public Title Title { get; set; }

        [Required(ErrorMessage = "Phone cannot be null.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = ("Address Description"))]
        public Address Address { get; set; }


        [Display(Name = ("Company Name"))]
        public Company Company { get; set; }

    }
}

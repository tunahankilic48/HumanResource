using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.CompanyManagerVMs
{
    public class CompanyManagerRegisterRequestsVM
    {
        public Guid UserId { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}

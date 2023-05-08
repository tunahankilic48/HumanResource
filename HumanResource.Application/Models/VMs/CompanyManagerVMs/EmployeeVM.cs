using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.CompanyManagerVMs
{
    public class EmployeeVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name ="Department")]
        public string DepartmentName { get; set; }

        [Display(Name ="Title")]
        public string Title { get; set; }
    }
}

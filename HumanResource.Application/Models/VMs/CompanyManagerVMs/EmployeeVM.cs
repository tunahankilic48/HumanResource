using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.CompanyManagerVMs
{
    public class EmployeeVM
    {
        public Guid Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name ="Department")]
        public string DepartmentName { get; set; }

        [Display(Name ="Title")]
        public string Title { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.CompanyVM
{
    public class CompanyVM
    {
        public int? Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Statu")]
        public string Statu { get; set; }
    }
}

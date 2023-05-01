using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.PersonelVM
{
    public class PersonelVM
    {
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        [Display(Name = "Departman")]
        public string Department { get; set; }
        public string FullName { get; set; }
    }
}

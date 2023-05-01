using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.PersonelVM
{
    public class PersonelAdvanceRequestsVM
    {
        [Display(Name ="Miktar")]
        public decimal Amount { get; set; }

        [Display(Name ="Taksit miktarı")]
        public int NumberOfInstallments { get; set; }

        [Display(Name ="Oluşturulma Tarihi")]
        public  DateTime CreatedDate { get; set; }
    }
}

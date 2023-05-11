using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.AdvanceVMs
{
    public class AdvanceVM
	{
        public int Id { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Number Of Installments")]
        public int NumberOfInstallments { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Advance Date")]
        public string AdvanceDate { get; set; }
        [Display(Name ="Manager")]
        public string ManagerName { get; set; }

    }
}

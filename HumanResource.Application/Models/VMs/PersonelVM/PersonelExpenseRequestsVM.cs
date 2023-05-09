using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.VMs.PersonelVM
{
    public class PersonelExpenseRequestsVM
    {
        public int Id { get; set; }

        [Display(Name = "Expense Created Date")]
        public string ExpenseDate { get; set; }

        [Display(Name = "owner of the expense")]
        public Guid UserId { get; set; }

        [Display(Name = "amount of expenditure")]
        public decimal Amount { get; set; }

        [Display(Name = "Expense Currency Type")]
        public int CurrencyTypeId { get; set; }
        [Display(Name = "Currency Type")]
        public string CurrencyType { get; set; }

        [Display(Name = "Expense Long Description")]
        public string LongDescription { get; set; }
        [Display(Name = "Expense Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Expense Type ID")]
        public int ExpenseTypeId { get; set; }
        [Display(Name = "Expense Type")]
        public string ExpenseType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

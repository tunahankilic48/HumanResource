using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.ExpenseDTO
{
    public class UpdateExpenseDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime CreatedDate => DateTime.Now;

        [Required(ErrorMessage = "Spend amount cannot be empty")]
        [Display(Name = "Spending amount")]
        public Decimal Amount { get; set; }

        [Required(ErrorMessage = "Description field cannot be null.")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Description field cannot be null.")]
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Expense Type cannot be null.")]
        [Display(Name = "Expense Type")]
        public int ExpenseTypeId { get; set; }

        [Required(ErrorMessage = "Currency Type cannot be null.")]
        [Display(Name = "Currency Type")]
        public int CurrencyTypeId { get; set; }

        [ValidateNever]
        public int StatuId { get; set; }
    }
}

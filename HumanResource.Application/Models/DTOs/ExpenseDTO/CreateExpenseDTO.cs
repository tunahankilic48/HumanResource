using HumanResource.Application.Extensions;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.DTOs.ExpenseDTO
{
    public class CreateExpenseDTO
    {
        public Guid UserId { get; set; }
        public DateTime CreatedDate => DateTime.Now;

        [Required(ErrorMessage = "Expense date cannot be null.")]
        [Display(Name = "Expense Date")]
        [DataType(DataType.Date), EndDate]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpenseDate { get; set; }

        [Required(ErrorMessage = "Spend amount cannot be empty")]
        [Display(Name = "Spending amount")]
        [Amount]
        public Decimal Amount { get; set; }

        [Required(ErrorMessage = "Description field cannot be null.")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string? LongDescription { get; set; }

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

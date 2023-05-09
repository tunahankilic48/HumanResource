using Bogus.DataSets;
using HumanResource.Application.Extensions;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.DTOs.ExpenseDTO
{
    public class CreateExpenseDTO
    {
        public CreateExpenseDTO()
        {
            Statu = new Statu();
        }
        public Guid UserId { get; set; }
        public DateTime CreatedDate => DateTime.Now;

        [Required(ErrorMessage = "Expense date cannot be null.")]
        [Display(Name = "Expense Date")]
        [DataType(DataType.Date), EndDate]
        public DateTime ExpenseDate { get; set; }

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
        public Statu Statu { get; set; }
    }
}

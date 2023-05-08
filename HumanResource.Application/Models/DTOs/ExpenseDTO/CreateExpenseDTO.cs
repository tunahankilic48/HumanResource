using Bogus.DataSets;
using HumanResource.Domain.Entities;
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
        public DateTime ExpenseDate => DateTime.Now;

        [Required(ErrorMessage = "Spend amount cannot be empty")]
        [Display(Name = "Spending amount")]
        public Decimal Amount { get; set; }

        [Required(ErrorMessage = "Description field cannot be null.")]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Expense Type cannot be null.")]
        [Display(Name = "Expense Type")]
        public int ExpenseTypeId { get; set; }


        [ValidateNever]
        public Statu Statu { get; set; }
    }
}

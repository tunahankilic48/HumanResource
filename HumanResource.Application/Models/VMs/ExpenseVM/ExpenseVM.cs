﻿using System.ComponentModel.DataAnnotations;

namespace HumanResource.Application.Models.VMs.ExpenseVM
{
    public class ExpenseVM
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
    }
}

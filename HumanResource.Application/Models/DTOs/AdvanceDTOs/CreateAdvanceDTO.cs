using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.DTOs.AdvanceDTOs
{
    public class CreateAdvanceDTO
    {
        public CreateAdvanceDTO()
        {
            Statu = new Statu();
        }

        [Required(ErrorMessage = "Amount field cannot be empty!")]
        [Range(0, 99999.99, ErrorMessage = "Please enter between 0-99999.99!")]
        [RegularExpression(@"^\d+$", ErrorMessage = "No letters or symbols can be entered!")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Installment field cannot be empty!")]
        [Range(0, 10, ErrorMessage = "Please enter between 0-10.")]
        public int NumberOfInstallments { get; set; }
        public string Description { get; set; }
        public DateTime AdvanceDate { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public Guid UserId { get; set; }



        [ValidateNever]
        public Statu Statu { get; set; }
        //ToDo: Tarih kısıtlaması için attibute yazılacak.

    }
}

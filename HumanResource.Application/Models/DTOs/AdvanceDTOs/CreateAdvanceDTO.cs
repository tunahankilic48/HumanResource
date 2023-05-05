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

		[Required(ErrorMessage = "Miktar alanı boş geçilemez!")]
		[Range(0,99999.99, ErrorMessage = "Lütfen 0-99999,99 arasında giriş yapınız.")]
		public decimal Amount { get; set; }
		
		[Required(ErrorMessage = "Taksit alanı boş geçilemez!")]
		[Range(0,20, ErrorMessage="Lütfen 0-20 arasında giriniz.")]
		public int NumberOfInstallments { get; set; }
		public DateTime CreatedDate => DateTime.Now;
		public Guid UserId { get; set; }



		[ValidateNever]
        public Statu Statu { get; set; }
        //ToDo: Tarih kısıtlaması için attibute yazılacak.

    }
}

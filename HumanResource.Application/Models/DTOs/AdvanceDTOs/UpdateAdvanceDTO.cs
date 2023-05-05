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
	public class UpdateAdvanceDTO
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Miktar alanı boş geçilemez!")]
		[Range(0,99999.99, ErrorMessage = "Lütfen 0-99999,99 arasında giriş yapınız.")]
		public decimal Amount { get; set; }
		
		[Required(ErrorMessage = "Taksit alanı boş geçilemez!")]
		[Range(0,10, ErrorMessage="Lütfen 0-10 arasında giriniz.")]
		public int NumberOfInstallments { get; set; }

        public DateTime ModifiedDate => DateTime.Now;

        [Required(ErrorMessage = "Güncelleme tarihi boş geçilemez!"), DataType(DataType.DateTime)]
		public DateTime CreatedDate { get; set; }
		public Guid UserId { get; set; }
        [ValidateNever]
        public int StatuId { get; set; }

		//ToDo: Tarih kısıtlaması için attibute yazılacak.
	}
}

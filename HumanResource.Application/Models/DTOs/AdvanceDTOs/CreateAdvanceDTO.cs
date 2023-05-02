using HumanResource.Domain.Entities;
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
		[Required(ErrorMessage = "Miktar alanı boş geçilemez!")]
		[Range(0,99999.99, ErrorMessage = "Lütfen 0-99999,99 arasında giriş yapınız.")]
		public decimal Amount { get; set; }
		
		[Required(ErrorMessage = "Taksit alanı boş geçilemez!")]
		[Range(0,10, ErrorMessage="Lütfen 0-10 arasında giriniz.")]
		public int NumberOfInstallments { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public Guid UserId { get; set; }

		public List<AppUser>? Users { get; set; }// sonradan eklendi 

		//public int StatuId { get; set; }
		//ToDo: Tarih kısıtlaması için attibute yazılacak.

	}
}

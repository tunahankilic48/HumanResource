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
		public decimal Amount { get; set; }
		[Required(ErrorMessage = "Taksit alanı boş geçilemez!")]
		public int NumberOfInstallments { get; set; }
		public DateTime CreateDate => DateTime.Now;
		public Guid UserId { get; set; }

		//public int StatuId { get; set; }
		//ToDo: Tarih kısıtlaması için attibute yazılacak.

	}
}

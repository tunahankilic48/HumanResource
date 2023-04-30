using HumanResource.Domain.Entities;
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
		public decimal Amount { get; set; }
		[Required(ErrorMessage = "Taksit alanı boş geçilemez!")]
		public int NumberOfInstallments { get; set; }
		[Required(ErrorMessage = "Oluşturulma tarihi boş geçilemez!"), DataType(DataType.DateTime)]
		public DateTime CreateDate { get; set; }
		[Required(ErrorMessage = "Güncelleme tarihi boş geçilemez!"), DataType(DataType.DateTime)]
		public DateTime ModifiedDate { get; set; }
		public Guid UserId { get; set; }

		//public int StatuId { get; set; }
		
		//ToDo: Tarih kısıtlaması için attibute yazılacak.
	}
}

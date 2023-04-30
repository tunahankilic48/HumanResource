using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Application.Models.VMs.AdvanceVMs
{
	public class AdvanceVM
	{
		public int Id { get; set; }
		[Display(Name = "Miktar")]
		public decimal Amount { get; set; }
		[Display(Name = "Taksit Sayısı")]
		public int NumberOfInstallments { get; set; }
		
	}
}

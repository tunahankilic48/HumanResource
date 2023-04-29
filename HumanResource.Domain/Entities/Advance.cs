using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class Advance : IBaseEntity
	{
		//avans tutarı , tarihi, taksit sayısı ve açıklama
		public int Id { get; set; }
		public decimal Amount { get; set; }
		public int NumberOfInstallments	{ get; set; }
		public Guid EmployeeId { get; set; }

		//NAvigation Property
		public Employee Employee { get; set; }
	}
}

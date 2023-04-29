using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class Leave : IBaseEntity
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public int LeaveTypeId { get; set; }
		public Guid UserId { get; set; }

		//Navigation Property
		public LeaveType LeaveType { get; set; }
		public AppUser User { get; set; }
	}
}

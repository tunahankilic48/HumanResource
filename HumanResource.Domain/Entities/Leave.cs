using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class Leave
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public int LeaveTypeId { get; set; }
		public Guid UserId { get; set; }
		public Guid SubstituteColleagueId { get; set; }

		//Navigation Property
		public LeaveType LeaveType { get; set; }
		public AppUser User { get; set; }
		public AppUser SubstituteColleague { get; set; }
	}
}

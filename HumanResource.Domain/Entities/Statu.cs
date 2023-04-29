using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class Statu
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }

		public List<AppUser> AppUsers { get; set; }
		public List<LeaveType> LeaveTypes { get; set; }
		public List<Leave> Leaves { get; set; }
		public List<Advance> Advances { get; set; }
		public List<Department> Departments { get; set; }

	}
}

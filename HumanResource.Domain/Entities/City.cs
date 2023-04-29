using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}

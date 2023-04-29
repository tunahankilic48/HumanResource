using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
	public class City : IBaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
        public int StatuId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Statu Statu { get; set; }

		public List<District> Districts { get; set; }
    }
}

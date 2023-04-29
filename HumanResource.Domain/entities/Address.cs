using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
    public class Address : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCode { get; set; }
        public int DistrictId { get; set; }
        public Guid UserId { get; set; }

        //navigation
        public District District { get; set; }
        public AppUser User { get; set; }
    }
}

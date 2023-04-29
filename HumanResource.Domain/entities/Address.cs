using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Domain.Entities
{
    public class Address : IBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCode { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }

        //navigation
        public City City { get; set; }
        public District District { get; set; }
    }
}

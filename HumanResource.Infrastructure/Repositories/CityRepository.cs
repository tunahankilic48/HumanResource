using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.Repositories
{
    internal class CityRepository : BaseRepository<City>
    {
        public CityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

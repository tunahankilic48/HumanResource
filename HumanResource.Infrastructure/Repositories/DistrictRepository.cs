using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    public class DistrictRepository : BaseRepository<District>
    {
        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

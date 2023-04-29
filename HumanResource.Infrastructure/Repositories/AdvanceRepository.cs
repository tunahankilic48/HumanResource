using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    internal class AdvanceRepository : BaseRepository<Advance>
    {
        public AdvanceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

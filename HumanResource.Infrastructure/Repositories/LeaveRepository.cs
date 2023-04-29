using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    internal class LeaveRepository : BaseRepository<Leave>
    {
        public LeaveRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

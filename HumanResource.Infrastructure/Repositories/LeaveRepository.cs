using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    public class LeaveRepository : BaseRepository<Leave>
    {
        public LeaveRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

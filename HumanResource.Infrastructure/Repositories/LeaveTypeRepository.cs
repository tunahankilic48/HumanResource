using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    public class LeaveTypeRepository : BaseRepository<LeaveType>
    {
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

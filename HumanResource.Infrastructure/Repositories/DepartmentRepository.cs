using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

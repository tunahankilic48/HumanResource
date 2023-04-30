using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    public class AppUserRepository : BaseRepository<AppUser>
    {
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

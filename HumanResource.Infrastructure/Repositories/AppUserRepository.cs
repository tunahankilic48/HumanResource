using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    internal class AppUserRepository : BaseRepository<AppUser>
    {
        public AppUserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

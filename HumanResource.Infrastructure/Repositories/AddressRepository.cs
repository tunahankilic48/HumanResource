using HumanResource.Domain.Entities;
using HumanResource.Infrastructure.DbContext;

namespace HumanResource.Infrastructure.Repositories
{
    internal class AddressRepository : BaseRepository<Address>
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

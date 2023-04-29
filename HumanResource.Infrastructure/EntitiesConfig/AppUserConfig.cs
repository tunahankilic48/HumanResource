using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    public class AppUserConfig : BaseEntityConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);

            base.Configure(builder);
        }
    }
}

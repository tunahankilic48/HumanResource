using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    internal class AdvanceConfig : BaseEntityConfig<Advance>
    {
        public override void Configure(EntityTypeBuilder<Advance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AppUser) // Advance in appuser ile ilişkisi
                .WithMany(x => x.Advances)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);



            base.Configure(builder);

        }
    }
}

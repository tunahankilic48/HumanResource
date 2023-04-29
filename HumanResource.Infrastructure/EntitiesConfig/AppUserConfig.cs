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
            builder.Property(x=>x.Id).HasColumnOrder(1);
            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30).IsUnicode(true)..HasColumnOrder(2);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50).IsUnicode(true).HasColumnOrder(3);
            builder.Property(x=>x.BirthDate).IsRequired(false).HasColumnType("date").HasColumnOrder(4);
            builder.Property(x => x.AddressId)
                .IsRequired(true).HasColumnOrder(5);
            builder.Property(x => x.DepartmentId)
                .IsRequired(true).HasColumnOrder(6);
            builder.Property(x => x.BloodTypeId)
                .IsRequired(true).HasColumnOrder(7);
            builder.Property(x => x.ManagerId)
                .IsRequired(true).HasColumnOrder(8);
            
            //Foreign Key ToDo: Kendi içinde eklenecek

            //Foreign Key
            builder.HasOne(x=>x.BloodType)
                    .WithMany(x=>x.Users)
                    .ForeignKey(x=>x.BloodTypeId);
            

            base.Configure(builder);
        }
    }
}

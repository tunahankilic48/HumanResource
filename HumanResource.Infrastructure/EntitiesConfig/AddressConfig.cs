using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    internal class AddressConfig : BaseEntityConfig<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.Name) //ToDo: adress çoka çok mu olmalı yoksa bire bir yapıp name mi silinmeli
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(50)")
                .HasColumnOrder(2);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .IsUnicode(true)
                .HasColumnType("NVARCHAR(MAX)")
                .HasColumnOrder(3);

            builder.Property(x => x.PostCode)
                .IsRequired(false)
                .HasColumnOrder(4);

            builder.Property(x => x.DistrictId)
                .IsRequired(true)
                .HasColumnOrder(5);

            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnOrder(6);

            //Foreign Key

            builder.HasOne(x => x.User)
                .WithOne(x => x.Address)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}

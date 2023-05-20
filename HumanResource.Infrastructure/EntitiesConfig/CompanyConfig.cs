using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    internal class CompanyConfig : BaseEntityConfig<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(1);

            builder.Property(x => x.CompanyName)
                .IsRequired(true)
                .HasColumnOrder(2);

            builder.Property(x => x.TaxNumber)
                .IsRequired(true)
                .HasColumnOrder(3);

            builder.Property(x => x.PhoneNumber)
                .IsRequired(true)
                .HasColumnOrder(4);

            builder.Property(x => x.NumberOfEmployee)
                .IsRequired(true)
                .HasColumnOrder(5);

            builder.Property(x => x.ImagePath)
                .IsRequired(false)
                .HasColumnOrder(6);

            // Foreign Key

            builder.HasMany(x => x.Departments)
               .WithOne(x => x.Company)
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Titles)
               .WithOne(x => x.Company)
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Users)
               .WithOne(x => x.Company)
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CompanySector)
               .WithMany(x => x.Companies)
               .HasForeignKey(x => x.CompanySectorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}

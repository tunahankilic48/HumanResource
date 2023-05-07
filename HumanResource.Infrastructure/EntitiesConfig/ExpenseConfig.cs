using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    public class ExpenseConfig : BaseEntityConfig<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.ExpenseType)
                .IsRequired(true)
                .HasColumnOrder(2);

            builder.Property(x => x.UserId)
                .IsRequired(true)
                .HasColumnOrder(3);

            builder.Property(x => x.ShortDescription)
                .IsRequired(true)
                .HasColumnOrder(4)
                .HasMaxLength(70);

            builder.Property(x => x.LongDescription)
                .IsRequired(false)
                .HasColumnOrder(5);

            builder.Property(x => x.ExpenseDate)
                .IsRequired(true)
                .HasColumnType("Date")
                .HasColumnOrder(6);

            builder.HasOne<AppUser>(x => x.User)
                .WithMany(x => x.Expenses)
                .HasForeignKey(x => x.UserId);

    
            base.Configure(builder);
            
        }
    }
}

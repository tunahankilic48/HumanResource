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
	internal class LeaveConfig : BaseEntityConfig<Leave>
	{
		public override void Configure(EntityTypeBuilder<Leave> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnOrder(1);

			builder.Property(x => x.StartDate)
					.IsRequired(true)
					.HasColumnType("date")
					.HasColumnOrder(2);


			builder.Property(x => x.EndDate)
					.IsRequired(true)
					.HasColumnType("date")
					.HasColumnOrder(3);


			builder.Property(x => x.ReturnDate)
					.IsRequired(true)
					.HasColumnType("date")
					.HasColumnOrder(4);

			builder.Property(x => x.LeaveTypeId)
					.IsRequired(true)
					.HasColumnOrder(5);

			builder.Property(x => x.UserId)
					.IsRequired(true)
					.HasColumnOrder(6);

			//Foreign Key
			builder.HasOne(x => x.LeaveType)
			   .WithMany(x => x.Leaves)
			   .HasForeignKey(x => x.LeaveTypeId)
							   .OnDelete(DeleteBehavior.Restrict);

		}
	}
}

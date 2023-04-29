using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Infrastructure.EntitiesConfig
{
	internal class DepartmentConfiguration : BaseEntitiyConfig<Department>
	{
		public override void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id)
				.HasColumnOrder(1);

			builder.Property(x => x.Name)
				.IsRequired(true)
				.IsUnicode(true)
				.HasMaxLength(255)
				.HasColumnOrder(2);

			builder.Property(x => x.StatuId)
				.IsRequired(true)
				.HasColumnOrder(3);

			base.Configure(builder);
		}
	}
}

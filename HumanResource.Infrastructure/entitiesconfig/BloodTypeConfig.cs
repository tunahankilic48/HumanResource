﻿using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    internal class BloodTypeConfig : BaseEntityConfig<BloodType>
    {
        public override void Configure(EntityTypeBuilder<BloodType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);

            base.Configure(builder);
        }
    }
}

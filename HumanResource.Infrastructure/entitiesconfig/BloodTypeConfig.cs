﻿using HumanResource.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Infrastructure.EntitiesConfig
{
    public class BloodTypeConfig : BaseEntityConfig<BloodType>
    {
        override void Configure(EntityTypeBuilder<BloodType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);

            base.Configure(builder);
        }
    }
}
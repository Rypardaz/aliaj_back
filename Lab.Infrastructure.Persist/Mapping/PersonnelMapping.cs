﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ex.Domain.PersonnelAgg;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class PersonnelMapping : IEntityTypeConfiguration<Personnel>
    {

        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.ToTable("tbPersonnel");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NationalCode);
            builder.Property(x => x.SalonId);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.Guid);
            builder.Property(x => x.IsRemoved);
            builder.Property(x => x.Created);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.LastModified);
            builder.Property(x => x.LastModifiedBy);
            builder.Ignore(x => x.EventAggregator);

            builder.Ignore(x => x.IsLocked);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ex.Domain.ActivityAgg;

namespace Lab.Infrastructure.Persist.Mapping;

public class ActivityMapping : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("tbActivity");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Type);
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
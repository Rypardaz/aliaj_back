using AM.Domain.PartGroupAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class PartGroupMapping : IEntityTypeConfiguration<PartGroup>
{

    public void Configure(EntityTypeBuilder<PartGroup> builder)
    {
        builder.ToTable("tbPartGroup");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
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
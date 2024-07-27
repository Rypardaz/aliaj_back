using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ex.Domain.PartAgg;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class PartMapping : IEntityTypeConfiguration<Part>
    {

        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("tbPart");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PartGroupId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.StandardWireConsumption);
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

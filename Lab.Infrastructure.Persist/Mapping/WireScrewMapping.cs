using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ex.Domain.WireScrewAgg;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class WireScrewMapping : IEntityTypeConfiguration<WireScrew>
    {

        public void Configure(EntityTypeBuilder<WireScrew> builder)
        {
            builder.ToTable("tbWireScrew");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.WireTypeId).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Screw).HasMaxLength(20).IsRequired();
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

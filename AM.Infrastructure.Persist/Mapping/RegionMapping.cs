using AM.Domain.RegionAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class RegionMapping : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        
        builder.ToTable("tbRegion");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
    }
}
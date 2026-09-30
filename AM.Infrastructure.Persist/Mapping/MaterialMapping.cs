using AM.Domain.MaterialAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class MaterialMapping : IEntityTypeConfiguration<Material>
{

    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.ToTable("tbMaterial");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
    }
}
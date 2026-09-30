using AM.Domain.UnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class UnitMapping : IEntityTypeConfiguration<Unit>
{

    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.ToTable("tbUnit");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
    }
}

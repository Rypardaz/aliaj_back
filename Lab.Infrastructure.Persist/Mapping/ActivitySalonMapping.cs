using Ex.Domain.ActivityAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class ActivitySalonMapping : IEntityTypeConfiguration<ActivitySalon>
{
    public void Configure(EntityTypeBuilder<ActivitySalon> builder)
    {
        builder.ToTable("tbActivitySalon");
        builder.HasKey(x => x.Id);
    }
}
using Ex.Domain.DailyRecordAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class DailyRecordMapping : IEntityTypeConfiguration<DailyRecord>
    {
        public void Configure(EntityTypeBuilder<DailyRecord> builder)
        {
            builder.ToTable("tbDailyRecord");
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.IsActive);
            builder.Ignore(x => x.IsLocked);

            builder.HasMany(x => x.Details)
                .WithOne(x => x.DailyRecord)
                .HasForeignKey(x => x.DailyRecordId);
        }
    }
}

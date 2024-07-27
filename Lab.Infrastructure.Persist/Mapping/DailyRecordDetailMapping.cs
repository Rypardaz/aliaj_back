using Ex.Domain.DailyRecordAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class DailyRecordDetailMapping : IEntityTypeConfiguration<DailyRecordDetail>
    {
        public void Configure(EntityTypeBuilder<DailyRecordDetail> builder)
        {
            builder.ToTable("tbDailyRecordDetail");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.DailyRecord)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.DailyRecordId);
        }
    }
}

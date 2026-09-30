using AM.Domain.TenderInquiryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class TenderInquiryMapping : IEntityTypeConfiguration<TenderInquiry>
{

    public void Configure(EntityTypeBuilder<TenderInquiry> builder)
    {
        builder.ToTable("tbTenderInquiry");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
    }
}

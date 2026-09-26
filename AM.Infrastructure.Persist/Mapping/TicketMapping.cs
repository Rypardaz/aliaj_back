using Ex.Domain.TicketAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class TicketMapping : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("tbTicket");
        builder.HasKey(x => x.Id);
    }
}
using Ex.Domain.WorkCalendarAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class WorkCalendarMapping : IEntityTypeConfiguration<WorkCalendar>
    {
        public void Configure(EntityTypeBuilder<WorkCalendar> builder)
        {
            builder.ToTable("tbWorkCalendar");
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.Guid);
            builder.Ignore(x => x.Created);
            builder.Ignore(x => x.CreatedBy);
            builder.Ignore(x => x.IsActive);
        }
    }
}

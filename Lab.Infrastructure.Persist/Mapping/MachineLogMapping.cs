using Ex.Domain.MachineLogAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class MachineLogMapping : IEntityTypeConfiguration<MachineLog>
    {
        public void Configure(EntityTypeBuilder<MachineLog> builder)
        {
            builder.ToTable("tbMachineLog");
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.Guid);
            builder.Ignore(x => x.IsActive);
            builder.Ignore(x => x.Created);
            builder.Ignore(x => x.CreatedBy);
        }
    }
}

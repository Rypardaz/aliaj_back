using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class OperationLogMapping : IEntityTypeConfiguration<PhoenixFramework.Logging.OperationLog>
{
    public void Configure(EntityTypeBuilder<PhoenixFramework.Logging.OperationLog> builder)
    {
        builder.ToTable("tbOperationLog", "Lab");
        builder.HasKey(x => x.Guid);
    }
}
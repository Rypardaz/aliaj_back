using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.OrganizationChartAgg;

namespace Lab.Infrastructure.Persist.Mapping;

public class OrganizationChartMapping : IEntityTypeConfiguration<OrganizationChart>
{
    public void Configure(EntityTypeBuilder<OrganizationChart> builder)
    {
        builder.ToTable("tbOrganizationChart", "USR");
        builder.HasKey(x => x.Id);
    }
}
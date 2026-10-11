using AM.Domain.ProjectDossierActualCostAdd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierActualCostMapping : IEntityTypeConfiguration<ProjectDossierActualCost>
{

    public void Configure(EntityTypeBuilder<ProjectDossierActualCost> builder)
    {
        builder.ToTable("tbProjectDossierActualCost");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
        builder.Ignore(x => x.IsActive);
    }
}

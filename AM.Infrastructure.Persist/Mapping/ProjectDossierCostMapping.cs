using AM.Domain.ProjectDossierCostAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierCostMapping : IEntityTypeConfiguration<ProjectDossierCost>
{

    public void Configure(EntityTypeBuilder<ProjectDossierCost> builder)
    {
        builder.ToTable("tbProjectDossierCost");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
        builder.Ignore(x => x.IsActive);
    }
}

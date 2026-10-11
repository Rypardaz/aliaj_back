using AM.Domain.ProjectDossierCostBeforImplementationAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierCostBeforImplementationMapping : IEntityTypeConfiguration<ProjectDossierCostBeforImplementation>
{

    public void Configure(EntityTypeBuilder<ProjectDossierCostBeforImplementation> builder)
    {
        builder.ToTable("tbProjectDossierCostBeforImplementation");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
        builder.Ignore(x => x.IsActive);
    }
}
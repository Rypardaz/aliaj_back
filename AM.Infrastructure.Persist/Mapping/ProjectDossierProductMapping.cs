using AM.Domain.ProjectDossierProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierProductMapping : IEntityTypeConfiguration<ProjectDossierProduct>
{

    public void Configure(EntityTypeBuilder<ProjectDossierProduct> builder)
    {
        builder.ToTable("tbProjectDossierProduct");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
        builder.Ignore(x => x.IsActive);
    }
}
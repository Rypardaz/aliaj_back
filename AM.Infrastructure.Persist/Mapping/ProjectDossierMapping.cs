using AM.Domain.ProjectDossierAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierMapping : IEntityTypeConfiguration<ProjectDossier>
{

    public void Configure(EntityTypeBuilder<ProjectDossier> builder)
    {
        builder.ToTable("tbTenderInquiry");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
    }
}

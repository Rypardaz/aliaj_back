using AM.Domain.ProjectDossierDepositAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierDepositMapping : IEntityTypeConfiguration<ProjectDossierDeposit>
{

    public void Configure(EntityTypeBuilder<ProjectDossierDeposit> builder)
    {
        builder.ToTable("tbProjectDossierDeposit");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
        builder.Ignore(x => x.IsActive);
    }
}

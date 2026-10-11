using AM.Domain.ProjectDossierInvoiceAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Persist.Mapping;

public class ProjectDossierInvoiceMapping : IEntityTypeConfiguration<ProjectDossierInvoice>
{

    public void Configure(EntityTypeBuilder<ProjectDossierInvoice> builder)
    {
        builder.ToTable("tbProjectDossierInvoice");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.EventAggregator);
        builder.Ignore(x => x.IsLocked);
        builder.Ignore(x => x.IsActive);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.CompanyAgg;

namespace Lab.Infrastructure.Persist.Mapping;

public class CompanyMapping : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("tbCompanies", "USR");
        builder.HasKey(x => x.Id);
    }
}
using Ex.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class RoleMapping : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("tbRoles");

        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Permissions)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId);
    }
}
using Ex.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class UserRoleMapping : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("tbUserRoles");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Roles)
            .HasForeignKey(x => x.UserId);

        builder.Ignore(x => x.Created);
        builder.Ignore(x => x.CreatedBy);
        builder.Ignore(x => x.IsActive);
    }
}

public class UserSalonMapping : IEntityTypeConfiguration<UserSalon>
{
    public void Configure(EntityTypeBuilder<UserSalon> builder)
    {
        builder.ToTable("tbUserSalons");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Salons)
            .HasForeignKey(x => x.UserId);

        builder.Ignore(x => x.Created);
        builder.Ignore(x => x.CreatedBy);
        builder.Ignore(x => x.IsActive);
    }
}
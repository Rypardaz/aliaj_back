using Ex.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tbUsers");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Sessions)
            .WithOne(x => x.User)
            .HasPrincipalKey(x => x.Guid);

        builder.Ignore(x => x.Claims);
    }
}
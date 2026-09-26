using Ex.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class UserPasswordMapping : IEntityTypeConfiguration<UserPassword>
{
    public void Configure(EntityTypeBuilder<UserPassword> builder)
    {
        builder.ToTable("tbUserPasswords");
        builder.HasKey(x => x.Id);
    }
}
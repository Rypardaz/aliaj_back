using Ex.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class UserSessionMapping : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("tbUserSessions");
        builder.HasKey(x => x.Id);
    }
}
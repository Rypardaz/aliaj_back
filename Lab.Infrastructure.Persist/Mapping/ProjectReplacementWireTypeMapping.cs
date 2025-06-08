using Ex.Domain.ProjectAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping;

public class ProjectReplacementWireTypeMapping : IEntityTypeConfiguration<ProjectReplacementWireType>
{
    public void Configure(EntityTypeBuilder<ProjectReplacementWireType> builder)
    {
        builder.ToTable("tbProjectReplacementWireTypes");
        builder.HasKey(x => x.Id);

        builder.Ignore(x => x.IsActive);

        builder.HasOne(x => x.Project)
            .WithMany(x => x.ReplacementWireTypes)
            .HasForeignKey(x => x.ProjectId);
    }
}
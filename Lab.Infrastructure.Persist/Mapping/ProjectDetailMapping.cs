using Ex.Domain.ProjectAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab.Infrastructure.Persist.Mapping
{
    public class ProjectDetailMapping : IEntityTypeConfiguration<ProjectDetail>
    {
        public void Configure(EntityTypeBuilder<ProjectDetail> builder)
        {
            builder.ToTable("tbProjectDetail");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.Details)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}

using Ex.Domain.ActivityAgg;
using Microsoft.EntityFrameworkCore;
using Lab.Infrastructure.Persist.Mapping;
using Ex.Domain.PartGroupAgg;
using Ex.Domain.PartAgg;
using Ex.Domain.ProjectAgg;
using Ex.Domain.TicketAgg;

namespace Lab.Infrastructure.Persist;

public class LaboratoryQueryContext : DbContext /*, IDbContext*/
{
    public DbSet<PartGroup> PartGroup { get; set; }
    public DbSet<Part> Part { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectDetail> ProjectDetails { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivitySalon> ActivitySalons { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public LaboratoryQueryContext(DbContextOptions<LaboratoryQueryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var assembly = typeof(PartGroupMapping).Assembly;
        builder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(builder);
    }
}
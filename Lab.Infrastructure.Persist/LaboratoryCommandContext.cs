using Ex.Domain.PartAgg;
using Ex.Domain.ProjectAgg;
using Ex.Domain.PartGroupAgg;
using Microsoft.EntityFrameworkCore;
using Lab.Infrastructure.Persist.Mapping;
using Ex.Domain.DailyRecordAgg;
using Ex.Domain.MachineLogAgg;
using Ex.Domain.MachineAgg;
using Ex.Domain.TicketAgg;
using Ex.Domain.WorkCalendarAgg;

namespace Lab.Infrastructure.Persist;

public class LaboratoryCommandContext : DbContext /*, IDbContext*/
{
    public DbSet<PartGroup> PartGroup { get; set; }
    public DbSet<Part> Part { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectDetail> ProjectDetails { get; set; }
    public DbSet<DailyRecord> DailyRecords { get; set; }
    public DbSet<PhoenixFramework.Logging.OperationLog> OperationLog { get; set; }
    public DbSet<MachineLog> MachineLog { get; set; }
    public DbSet<Machine> Machine { get; set; }
    public DbSet<WorkCalendar> WorkCalendar { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    public LaboratoryCommandContext(DbContextOptions<LaboratoryCommandContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var assembly = typeof(PartGroupMapping).Assembly;
        builder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(builder);
    }
}
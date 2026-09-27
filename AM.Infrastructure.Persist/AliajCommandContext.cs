using AM.Domain.DailyRecordAgg;
using AM.Domain.MachineAgg;
using AM.Domain.MachineLogAgg;
using AM.Domain.PartAgg;
using AM.Domain.PartGroupAgg;
using AM.Domain.ProjectAgg;
using AM.Domain.RoleAgg;
using AM.Domain.TicketAgg;
using AM.Domain.UserAgg;
using AM.Domain.WorkCalendarAgg;
using AM.Infrastructure.Persist.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure.Persist;

public class AliajCommandContext(DbContextOptions<AliajCommandContext> options) : DbContext(options) /*, IDbContext*/
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
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var assembly = typeof(PartGroupMapping).Assembly;
        builder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(builder);
    }
}
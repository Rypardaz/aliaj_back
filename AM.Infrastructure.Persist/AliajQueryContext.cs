using AM.Domain.ActivityAgg;
using AM.Domain.PartAgg;
using AM.Domain.PartGroupAgg;
using AM.Domain.ProjectAgg;
using AM.Domain.RegionAgg;
using AM.Domain.RoleAgg;
using AM.Domain.TicketAgg;
using AM.Domain.UserAgg;
using AM.Infrastructure.Persist.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure.Persist;

public class AliajQueryContext(DbContextOptions<AliajQueryContext> options)
    : DbContext(options)
{
    public DbSet<PartGroup> PartGroup { get; set; }
    public DbSet<Part> Part { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectDetail> ProjectDetails { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivitySalon> ActivitySalons { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var assembly = typeof(PartGroupMapping).Assembly;
        builder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(builder);
    }
}
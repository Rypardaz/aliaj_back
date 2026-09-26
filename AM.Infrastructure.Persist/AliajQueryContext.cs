using Ex.Domain.ActivityAgg;
using Microsoft.EntityFrameworkCore;
using Lab.Infrastructure.Persist.Mapping;
using Ex.Domain.PartGroupAgg;
using Ex.Domain.PartAgg;
using Ex.Domain.ProjectAgg;
using Ex.Domain.RoleAgg;
using Ex.Domain.TicketAgg;
using Ex.Domain.UserAgg;

namespace Lab.Infrastructure.Persist;

public class AliajQueryContext(DbContextOptions<AliajQueryContext> options)
    : DbContext(options) /*, IDbContext*/
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var assembly = typeof(PartGroupMapping).Assembly;
        builder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(builder);
    }
}
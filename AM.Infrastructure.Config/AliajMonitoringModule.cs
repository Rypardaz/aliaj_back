using AM.Application;
using AM.Domain.PartGroupAgg.Service;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Persist.Repository;
using AM.Infrastructure.Query;
using AM.Infrastructure.Report;
using AM.Presentation.Facade.Command;
using AM.Presentation.Facade.Query;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Autofac;
using PhoenixFramework.Domain;
using PhoenixFramework.Identity;

namespace AM.Infrastructure.Config;

public class AliajMonitoringModule(string connectionString) : Module
{
    public string ConnectionString { get; set; } = connectionString;

    protected override void Load(ContainerBuilder builder)
    {
        var commandHandlersAssembly = typeof(PartGroupCommandHandler).Assembly;
        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandler<,>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandlerAsync<>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commandHandlersAssembly)
            .AsClosedTypesOf(typeof(ICommandHandlerAsync<,>))
            .InstancePerLifetimeScope();

        var queryHandlerAssembly = typeof(PartGroupQueryHandler).Assembly;
        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandler<>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandlerAsync<>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(queryHandlerAssembly)
            .AsClosedTypesOf(typeof(IQueryHandlerAsync<,>))
            .InstancePerDependency();

        builder.Register(_ =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AliajCommandContext>();
                optionsBuilder.UseSqlServer(ConnectionString);
                return new AliajCommandContext(optionsBuilder.Options);
            })
            .As<DbContext>()
            .As<AliajCommandContext>()
            .InstancePerLifetimeScope();

        builder.Register(_ =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AliajQueryContext>();
                optionsBuilder.UseSqlServer(ConnectionString);
                return new AliajQueryContext(optionsBuilder.Options);
            })
            .As<AliajQueryContext>()
            .InstancePerDependency();

        var repositoryAssembly = typeof(PartGroupRepository).Assembly;
        builder.RegisterAssemblyTypes(repositoryAssembly)
            .AsClosedTypesOf(typeof(IRepository<,>))
            .InstancePerLifetimeScope();

        var domainServiceAssembly = typeof(PartGroupService).Assembly;
        builder.RegisterAssemblyTypes(domainServiceAssembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        var facadeAssembly = typeof(PartGroupCommandFacade).Assembly;
        builder.RegisterAssemblyTypes(facadeAssembly)
            .Where(t => t.Name.EndsWith("CommandFacade"))
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SecurityInterceptor))
            .AsImplementedInterfaces();

        var facadeQueryAssembly = typeof(PartGroupQueryFacade).Assembly;
        builder.RegisterAssemblyTypes(facadeQueryAssembly)
            .Where(t => t.Name.EndsWith("QueryFacade"))
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(SecurityInterceptor))
            .AsImplementedInterfaces();

        var reportAssembly = typeof(DailyReportService).Assembly;
        builder.RegisterAssemblyTypes(reportAssembly)
            .Where(t => t.Name.EndsWith("ReportService"))
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .AsImplementedInterfaces();

        builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();

        base.Load(builder);
    }
}
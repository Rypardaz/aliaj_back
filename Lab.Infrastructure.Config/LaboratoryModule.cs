using Autofac;
using Lab.Infrastructure.Persist;
using Lab.Infrastructure.Persist.Repository;
using Lab.Infrastructure.Query;
using Lab.Presentation.Facade.Command;
using Lab.Presentation.Facade.Query;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Domain;
using PhoenixFramework.Autofac;
using Autofac.Extras.DynamicProxy;
using Ex.Application;
using Ex.Domain.PartGroupAgg.Service;
using Lab.Infrastructure.Report;
using Lab.Infrastructure.Report.Contract.Management;

namespace Lab.Infrastructure.Config;

public class LaboratoryModule : Module
{
    public string ConnectionString { get; set; }

    public LaboratoryModule(string connectionString)
    {
        ConnectionString = connectionString;
    }

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

        // var mappingAssembly = typeof(DecisionRuleMapping).Assembly;
        // var userManagementAssembly = typeof(UserMapping).Assembly;
        //
        // var types = mappingAssembly.GetExportedTypes().ToList();
        // var userManagementMappings = userManagementAssembly.GetExportedTypes().ToList();
        //
        // types.AddRange(userManagementMappings);

        builder.Register(_ =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<LaboratoryCommandContext>();
                optionsBuilder.UseSqlServer(ConnectionString);
                return new LaboratoryCommandContext(optionsBuilder.Options);
            })
            .As<DbContext>()
            .As<LaboratoryCommandContext>()
            .InstancePerLifetimeScope();

        builder.Register(_ =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<LaboratoryQueryContext>();
                optionsBuilder.UseSqlServer(ConnectionString);
                return new LaboratoryQueryContext(optionsBuilder.Options);
            })
            .As<LaboratoryQueryContext>()
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

        // var infraServiceAssembly = typeof(DocumentAccountingService).Assembly;
        //
        // builder.RegisterAssemblyTypes(infraServiceAssembly)
        //     .Where(t => t.Name.EndsWith("Service"))
        //     .AsImplementedInterfaces()
        //     .InstancePerLifetimeScope();

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

        var reportAssembly = typeof(ManagementReportService).Assembly;
        builder.RegisterAssemblyTypes(reportAssembly)
            .Where(t => t.Name.EndsWith("ReportService"))
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()
            .AsImplementedInterfaces();

        // var reportServiceAssembly = typeof(JournalReportService).Assembly;
        // builder.RegisterAssemblyTypes(reportServiceAssembly)
        //     .Where(t => t.Name.EndsWith("ReportService"))
        //     .InstancePerLifetimeScope()
        //     .EnableInterfaceInterceptors()
        //     .InterceptedBy(typeof(SecurityInterceptor))
        //     .AsImplementedInterfaces();
        //
        // builder.RegisterType<FloatingAccountAcl>()
        //     .As<IFloatingAccountAcl>()
        //     .InstancePerLifetimeScope();

        base.Load(builder);
    }
}
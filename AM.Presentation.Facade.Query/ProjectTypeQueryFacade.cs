using Ex.Application.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.ProjectType;
using Lab.Presentation.Facade.Contract.ProjectType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class ProjectTypeQueryFacade(IQueryBus queryBus) : IProjectTypeQueryFacade
{
    public EditProjectType GetDetails(Guid guid) => queryBus.Dispatch<EditProjectType, Guid>(guid);

    public List<ProjectTypeViewModel> List() => queryBus.Dispatch<List<ProjectTypeViewModel>>();

    public List<ProjectTypeComboModel> Combo(Guid salonGuid) => 
        queryBus.Dispatch<List<ProjectTypeComboModel>, Guid>(salonGuid);
}
using AM.Application.Contracts.ProjectType;
using AM.Infrastructure.Query.Contract.ProjectType;
using AM.Presentation.Facade.Contract.ProjectType;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ProjectTypeQueryFacade(IQueryBus queryBus) : IProjectTypeQueryFacade
{
    public EditProjectType GetDetails(Guid guid) => queryBus.Dispatch<EditProjectType, Guid>(guid);

    public List<ProjectTypeViewModel> List() => queryBus.Dispatch<List<ProjectTypeViewModel>>();

    public List<ProjectTypeComboModel> Combo(Guid salonGuid) => 
        queryBus.Dispatch<List<ProjectTypeComboModel>, Guid>(salonGuid);
}
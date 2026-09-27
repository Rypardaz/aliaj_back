using AM.Application.Contracts.ProjectType;
using AM.Infrastructure.Query.Contract.ProjectType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectType;

public interface IProjectTypeQueryFacade : IFacadeService
{
    List<ProjectTypeViewModel> List();
    EditProjectType GetDetails(Guid guid);
    List<ProjectTypeComboModel> Combo(Guid salonGuid);
}
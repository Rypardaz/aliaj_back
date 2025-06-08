using Ex.Application.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.ProjectType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.ProjectType
{
    public interface IProjectTypeQueryFacade : IFacadeService
    {
        List<ProjectTypeViewModel> List();
        EditProjectType GetDetails(Guid guid);
        List<ProjectTypeComboModel> Combo(Guid salonGuid);
    }
}

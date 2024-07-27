using Ex.Application.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.ProjectType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.ProjectType
{
    public interface IProjectTypeQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<ProjectTypeViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditProjectType GetDetails(Guid guid);
        List<ProjectTypeComboModel> Combo(Guid salonGuid);
    }
}

using PhoenixFramework.Core;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Project;
using Lab.Infrastructure.Query.Contracts.Project;

namespace Lab.Presentation.Facade.Contract.Project
{
    public interface IProjectQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<ProjectViewModel> List(ProjectSearchModel searchModel);
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditProject GetDetails(Guid guid);
        List<ProjectComboModel> Combo();
        List<ProjectDetailComboModel> DetailsCombo(Guid salonGuid);
    }
}

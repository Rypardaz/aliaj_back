using PhoenixFramework.Core;
using Ex.Application.Contracts.Project;
using Lab.Infrastructure.Query.Contracts.Project;

namespace Lab.Presentation.Facade.Contract.Project;

public interface IProjectQueryFacade : IFacadeService
{
    List<ProjectViewModel> List(ProjectSearchModel searchModel);

    EditProject GetDetails(Guid guid);
    List<ProjectComboModel> Combo();
    List<ProjectDetailComboModel> DetailsCombo(Guid projectGuid);
    List<ProjectReplacementWireTypeViewModel> GetReplacements(Guid projectGuid);
    List<ProjectStepViewModel> GetProjectStep(ProjectStepSearchModel searchModel);
}
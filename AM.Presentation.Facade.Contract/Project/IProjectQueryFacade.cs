using AM.Application.Contracts.Project;
using AM.Infrastructure.Query.Contract.Project;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Project;

public interface IProjectQueryFacade : IFacadeService
{
    List<ProjectViewModel> List(ProjectSearchModel searchModel);

    EditProject GetDetails(Guid guid);
    List<ProjectComboModel> Combo(ProjectSearchModel searchModel);
    List<ProjectDetailComboModel> DetailsCombo(Guid projectGuid);
    List<ProjectReplacementWireTypeViewModel> GetReplacements(Guid projectGuid);
    List<ProjectStepViewModel> GetProjectStep(ProjectStepSearchModel searchModel);
}
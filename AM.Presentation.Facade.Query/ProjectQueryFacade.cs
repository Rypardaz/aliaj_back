using Ex.Application.Contracts.Project;
using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.Project;
using Lab.Infrastructure.Query.Contracts.Project;

namespace Lab.Presentation.Facade.Query;

public class ProjectQueryFacade(IQueryBus queryBus) : IProjectQueryFacade
{
    public EditProject GetDetails(Guid guid) => queryBus.Dispatch<EditProject, Guid>(guid);

    public List<ProjectViewModel> List(ProjectSearchModel searchModel) =>
        queryBus.Dispatch<List<ProjectViewModel>, ProjectSearchModel>(searchModel);

    public List<ProjectComboModel> Combo(ProjectSearchModel searchModel) =>
        queryBus.Dispatch<List<ProjectComboModel>, ProjectSearchModel>(searchModel);

    public List<ProjectDetailComboModel> DetailsCombo(Guid projectGuid) =>
        queryBus.Dispatch<List<ProjectDetailComboModel>, Guid>(projectGuid);

    public List<ProjectReplacementWireTypeViewModel> GetReplacements(Guid projectGuid) =>
        queryBus.Dispatch<List<ProjectReplacementWireTypeViewModel>, Guid>(projectGuid);

    public List<ProjectStepViewModel> GetProjectStep(ProjectStepSearchModel searchModel) =>
        queryBus.Dispatch<List<ProjectStepViewModel>, ProjectStepSearchModel>(searchModel);
}
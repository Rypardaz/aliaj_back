using Ex.Application.Contracts.Project;
using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.Project;
using Lab.Infrastructure.Query.Contracts.Project;

namespace Lab.Presentation.Facade.Query
{
    public class ProjectQueryFacade : IProjectQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public ProjectQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditProject GetDetails(Guid guid) => _queryBus.Dispatch<EditProject, Guid>(guid);

        public List<ProjectViewModel> List(ProjectSearchModel searchModel) => _queryBus.Dispatch<List<ProjectViewModel>, ProjectSearchModel>(searchModel);

        public List<ProjectComboModel> Combo() => _queryBus.Dispatch<List<ProjectComboModel>>();

        public List<ProjectDetailComboModel> DetailsCombo(Guid salonGuid) =>
            _queryBus.Dispatch<List<ProjectDetailComboModel>, Guid>(salonGuid);
    }
}
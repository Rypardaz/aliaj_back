using Ex.Application.Contracts.ProjectType;
using Lab.Infrastructure.Query.Contracts.ProjectType;
using Lab.Presentation.Facade.Contract.ProjectType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class ProjectTypeQueryFacade : IProjectTypeQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public ProjectTypeQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditProjectType GetDetails(Guid guid) => _queryBus.Dispatch<EditProjectType, Guid>(guid);

        public List<ProjectTypeViewModel> List() => _queryBus.Dispatch<List<ProjectTypeViewModel>>();

        public List<ProjectTypeComboModel> Combo(Guid salonGuid) => 
            _queryBus.Dispatch<List<ProjectTypeComboModel>, Guid>(salonGuid);
    }
}

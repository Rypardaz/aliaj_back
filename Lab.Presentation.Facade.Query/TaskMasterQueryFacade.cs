using Ex.Application.Contracts.TaskMaster;
using Lab.Infrastructure.Query.Contracts.TaskMaster;
using Lab.Presentation.Facade.Contract.TaskMaster;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class TaskMasterQueryFacade : ITaskMasterQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public TaskMasterQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditTaskMaster GetDetails(Guid guid) => _queryBus.Dispatch<EditTaskMaster, Guid>(guid);

        public List<TaskMasterViewModel> List() => _queryBus.Dispatch<List<TaskMasterViewModel>>();

        public List<TaskMasterComboModel> Combo() => _queryBus.Dispatch<List<TaskMasterComboModel>>();
    }
}

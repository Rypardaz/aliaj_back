using AM.Application.Contracts.TaskMaster;
using AM.Infrastructure.Query.Contract.TaskMaster;
using AM.Presentation.Facade.Contract.TaskMaster;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class TaskMasterQueryFacade(IQueryBus queryBus) : ITaskMasterQueryFacade
{
    public EditTaskMaster GetDetails(Guid guid) => queryBus.Dispatch<EditTaskMaster, Guid>(guid);

    public List<TaskMasterViewModel> List() => queryBus.Dispatch<List<TaskMasterViewModel>>();

    public List<TaskMasterComboModel> Combo() => queryBus.Dispatch<List<TaskMasterComboModel>>();
}
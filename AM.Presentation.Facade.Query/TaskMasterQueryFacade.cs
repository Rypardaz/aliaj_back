using Ex.Application.Contracts.TaskMaster;
using Lab.Infrastructure.Query.Contracts.TaskMaster;
using Lab.Presentation.Facade.Contract.TaskMaster;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class TaskMasterQueryFacade(IQueryBus queryBus) : ITaskMasterQueryFacade
{
    public EditTaskMaster GetDetails(Guid guid) => queryBus.Dispatch<EditTaskMaster, Guid>(guid);

    public List<TaskMasterViewModel> List() => queryBus.Dispatch<List<TaskMasterViewModel>>();

    public List<TaskMasterComboModel> Combo() => queryBus.Dispatch<List<TaskMasterComboModel>>();
}
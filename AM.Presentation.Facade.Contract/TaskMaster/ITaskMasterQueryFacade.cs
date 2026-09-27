using AM.Application.Contracts.TaskMaster;
using AM.Infrastructure.Query.Contract.TaskMaster;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TaskMaster;

public interface ITaskMasterQueryFacade : IFacadeService
{
        
    List<TaskMasterViewModel> List();
        
    EditTaskMaster GetDetails(Guid guid);
    List<TaskMasterComboModel> Combo();
}
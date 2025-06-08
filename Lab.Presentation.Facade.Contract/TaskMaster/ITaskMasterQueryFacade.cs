using Ex.Application.Contracts.TaskMaster;
using Lab.Infrastructure.Query.Contracts.TaskMaster;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.TaskMaster
{
    public interface ITaskMasterQueryFacade : IFacadeService
    {
        
        List<TaskMasterViewModel> List();
        
        EditTaskMaster GetDetails(Guid guid);
        List<TaskMasterComboModel> Combo();
    }
}

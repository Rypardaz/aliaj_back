using Ex.Application.Contracts.TaskMaster;
using Lab.Infrastructure.Query.Contracts.TaskMaster;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.TaskMaster
{
    public interface ITaskMasterQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<TaskMasterViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditTaskMaster GetDetails(Guid guid);
        List<TaskMasterComboModel> Combo();
    }
}

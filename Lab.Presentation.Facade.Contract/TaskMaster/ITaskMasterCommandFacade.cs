using Ex.Application.Contracts.TaskMaster;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.TaskMaster
{
    public interface ITaskMasterCommandFacade : IFacadeService
    {
        Guid Create(CreateTaskMaster command);
        void Edit(EditTaskMaster command);
        void Delete(Guid guid);
        void Activate(Guid guid);
        void Deactivate(Guid guid);
    }
}

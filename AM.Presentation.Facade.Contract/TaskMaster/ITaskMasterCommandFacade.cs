using AM.Application.Contracts.TaskMaster;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.TaskMaster;

public interface ITaskMasterCommandFacade : IFacadeService
{
    Guid Create(CreateTaskMaster command);
    void Edit(EditTaskMaster command);
    void Delete(Guid guid);
    void Activate(Guid guid);
    void Deactivate(Guid guid);
}
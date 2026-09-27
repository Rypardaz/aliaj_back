using AM.Application.Contracts.MachineLog;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.MachineLog;

public interface IMachineLogCommandFacade : IFacadeService
{
    void Create(CreateMachineLog command);
}
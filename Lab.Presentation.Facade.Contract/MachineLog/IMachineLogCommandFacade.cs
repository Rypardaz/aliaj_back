using Ex.Application.Contracts.Machine;
using Ex.Application.Contracts.MachineLog;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.MachineLog
{
    public interface IMachineLogCommandFacade : IFacadeService
    {
        void Create(CreateMachineLog command);
    }
}

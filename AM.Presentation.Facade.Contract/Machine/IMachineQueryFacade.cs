using AM.Application.Contracts.Machine;
using AM.Infrastructure.Query.Contract.Machine;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Machine;

public interface IMachineQueryFacade : IFacadeService
{
    
    List<MachineViewModel> List();
    
    EditMachine GetDetails(Guid guid);
    List<MachineComboModel> Combo(Guid? salonGuid);
}
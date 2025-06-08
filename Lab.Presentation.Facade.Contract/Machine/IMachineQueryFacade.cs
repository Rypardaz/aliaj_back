using Ex.Application.Contracts.Machine;
using Lab.Infrastructure.Query.Contracts.Machine;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Machine;

public interface IMachineQueryFacade : IFacadeService
{
    
    List<MachineViewModel> List();
    
    EditMachine GetDetails(Guid guid);
    List<MachineComboModel> Combo(Guid? salonGuid);
}
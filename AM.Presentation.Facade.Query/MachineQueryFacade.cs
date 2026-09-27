using AM.Application.Contracts.Machine;
using AM.Infrastructure.Query.Contract.Machine;
using AM.Presentation.Facade.Contract.Machine;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class MachineQueryFacade(IQueryBus queryBus) : IMachineQueryFacade
{
    public EditMachine GetDetails(Guid guid) => queryBus.Dispatch<EditMachine, Guid>(guid);

    public List<MachineViewModel> List() => queryBus.Dispatch<List<MachineViewModel>>();

    public List<MachineComboModel> Combo(Guid? salonGuid) => queryBus.Dispatch<List<MachineComboModel>, Guid?>(salonGuid);
}
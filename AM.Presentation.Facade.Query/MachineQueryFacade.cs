using Ex.Application.Contracts.Machine;
using Lab.Infrastructure.Query.Contracts.Machine;
using Lab.Presentation.Facade.Contract.Machine;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class MachineQueryFacade(IQueryBus queryBus) : IMachineQueryFacade
{
    public EditMachine GetDetails(Guid guid) => queryBus.Dispatch<EditMachine, Guid>(guid);

    public List<MachineViewModel> List() => queryBus.Dispatch<List<MachineViewModel>>();

    public List<MachineComboModel> Combo(Guid? salonGuid) => queryBus.Dispatch<List<MachineComboModel>, Guid?>(salonGuid);
}
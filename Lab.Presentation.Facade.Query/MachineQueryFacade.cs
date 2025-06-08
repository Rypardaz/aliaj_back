using Ex.Application.Contracts.Machine;
using Lab.Infrastructure.Query.Contracts.Machine;
using Lab.Presentation.Facade.Contract.Machine;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class MachineQueryFacade : IMachineQueryFacade
{
    private readonly IQueryBus _queryBus;

    public MachineQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

    public EditMachine GetDetails(Guid guid) => _queryBus.Dispatch<EditMachine, Guid>(guid);

    public List<MachineViewModel> List() => _queryBus.Dispatch<List<MachineViewModel>>();

    public List<MachineComboModel> Combo(Guid? salonGuid) => _queryBus.Dispatch<List<MachineComboModel>, Guid?>(salonGuid);
}
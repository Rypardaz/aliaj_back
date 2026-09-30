using AM.Application.Contracts.Unit;
using AM.Infrastructure.Query.Contract.Unit;
using AM.Presentation.Facade.Contract.Unit;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class UnitQueryFacade(IQueryBus queryBus) : IUnitQueryFacade
{
    public EditUnit GetDetails(Guid guid) => queryBus.Dispatch<EditUnit, Guid>(guid);

    public List<UnitViewModel> List() => queryBus.Dispatch<List<UnitViewModel>>();

    public List<UnitComboModel> Combo(Guid? salonGuid) =>
        queryBus.Dispatch<List<UnitComboModel>, Guid?>(salonGuid);
}
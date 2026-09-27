using AM.Application.Contracts.GasType;
using AM.Infrastructure.Query.Contract.GasType;
using AM.Presentation.Facade.Contract.GasType;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class GasTypeQueryFacade(IQueryBus queryBus) : IGasTypeQueryFacade
{
    public EditGasType GetDetails(Guid guid) => queryBus.Dispatch<EditGasType, Guid>(guid);

    public List<GasTypeViewModel> List() => queryBus.Dispatch<List<GasTypeViewModel>>();

    public List<GasTypeComboModel> Combo() => queryBus.Dispatch<List<GasTypeComboModel>>();
}
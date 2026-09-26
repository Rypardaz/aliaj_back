using Ex.Application.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.GasType;
using Lab.Presentation.Facade.Contract.GasType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class GasTypeQueryFacade(IQueryBus queryBus) : IGasTypeQueryFacade
{
    public EditGasType GetDetails(Guid guid) => queryBus.Dispatch<EditGasType, Guid>(guid);

    public List<GasTypeViewModel> List() => queryBus.Dispatch<List<GasTypeViewModel>>();

    public List<GasTypeComboModel> Combo() => queryBus.Dispatch<List<GasTypeComboModel>>();
}
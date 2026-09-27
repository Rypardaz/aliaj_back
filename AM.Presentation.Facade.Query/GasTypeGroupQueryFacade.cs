using AM.Application.Contracts.GasTypeGroup;
using AM.Infrastructure.Query.Contract.GasTypeGroup;
using AM.Presentation.Facade.Contract.GasTypeGroup;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class GasTypeGroupQueryFacade(IQueryBus queryBus) : IGasTypeGroupQueryFacade
{
    public EditGasTypeGroup GetDetails(Guid guid) => queryBus.Dispatch<EditGasTypeGroup, Guid>(guid);

    public List<GasTypeGroupViewModel> List() => queryBus.Dispatch<List<GasTypeGroupViewModel>>();

    public List<GasTypeGroupComboModel> Combo() => queryBus.Dispatch<List<GasTypeGroupComboModel>>();
}
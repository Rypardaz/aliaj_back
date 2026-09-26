using Ex.Application.Contracts.GasTypeGroup;
using Lab.Infrastructure.Query.Contracts.GasTypeGroup;
using Lab.Presentation.Facade.Contract.GasTypeGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class GasTypeGroupQueryFacade(IQueryBus queryBus) : IGasTypeGroupQueryFacade
{
    public EditGasTypeGroup GetDetails(Guid guid) => queryBus.Dispatch<EditGasTypeGroup, Guid>(guid);

    public List<GasTypeGroupViewModel> List() => queryBus.Dispatch<List<GasTypeGroupViewModel>>();

    public List<GasTypeGroupComboModel> Combo() => queryBus.Dispatch<List<GasTypeGroupComboModel>>();
}
using AM.Application.Contracts.WireTypeGroup;
using AM.Infrastructure.Query.Contract.WireTypeGroup;
using AM.Presentation.Facade.Contract.WireTypeGroup;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class WireTypeGroupQueryFacade(IQueryBus queryBus) : IWireTypeGroupQueryFacade
{
    public EditWireTypeGroup GetDetails(Guid guid) => queryBus.Dispatch<EditWireTypeGroup, Guid>(guid);

    public List<WireTypeGroupViewModel> List() => queryBus.Dispatch<List<WireTypeGroupViewModel>>();

    public List<WireTypeGroupComboModel> Combo() => queryBus.Dispatch<List<WireTypeGroupComboModel>>();
}
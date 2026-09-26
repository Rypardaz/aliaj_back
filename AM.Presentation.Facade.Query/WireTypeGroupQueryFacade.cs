using Ex.Application.Contracts.WireTypeGroup;
using Lab.Infrastructure.Query.Contracts.WireTypeGroup;
using Lab.Presentation.Facade.Contract.WireTypeGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class WireTypeGroupQueryFacade(IQueryBus queryBus) : IWireTypeGroupQueryFacade
{
    public EditWireTypeGroup GetDetails(Guid guid) => queryBus.Dispatch<EditWireTypeGroup, Guid>(guid);

    public List<WireTypeGroupViewModel> List() => queryBus.Dispatch<List<WireTypeGroupViewModel>>();

    public List<WireTypeGroupComboModel> Combo() => queryBus.Dispatch<List<WireTypeGroupComboModel>>();
}
using AM.Application.Contracts.WireType;
using AM.Infrastructure.Query.Contract.WireType;
using AM.Presentation.Facade.Contract.WireType;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class WireTypeQueryFacade(IQueryBus queryBus) : IWireTypeQueryFacade
{
    public EditWireType GetDetails(Guid guid) => queryBus.Dispatch<EditWireType, Guid>(guid);

    public List<WireTypeViewModel> List() => queryBus.Dispatch<List<WireTypeViewModel>>();

    public List<WireTypeComboModel> Combo() => queryBus.Dispatch<List<WireTypeComboModel>>();
}
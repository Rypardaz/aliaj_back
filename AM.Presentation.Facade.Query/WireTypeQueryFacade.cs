using Ex.Application.Contracts.WireType;
using Lab.Infrastructure.Query.Contracts.WireType;
using Lab.Presentation.Facade.Contract.WireType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class WireTypeQueryFacade(IQueryBus queryBus) : IWireTypeQueryFacade
{
    public EditWireType GetDetails(Guid guid) => queryBus.Dispatch<EditWireType, Guid>(guid);

    public List<WireTypeViewModel> List() => queryBus.Dispatch<List<WireTypeViewModel>>();

    public List<WireTypeComboModel> Combo() => queryBus.Dispatch<List<WireTypeComboModel>>();
}
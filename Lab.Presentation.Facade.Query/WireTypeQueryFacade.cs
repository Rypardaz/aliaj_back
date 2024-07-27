using Ex.Application.Contracts.WireType;
using Lab.Infrastructure.Query.Contracts.WireType;
using Lab.Presentation.Facade.Contract.WireType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class WireTypeQueryFacade : IWireTypeQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public WireTypeQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditWireType GetDetails(Guid guid) => _queryBus.Dispatch<EditWireType, Guid>(guid);

        public List<WireTypeViewModel> List() => _queryBus.Dispatch<List<WireTypeViewModel>>();

        public List<WireTypeComboModel> Combo() => _queryBus.Dispatch<List<WireTypeComboModel>>();
    }
}

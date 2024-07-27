using Ex.Application.Contracts.WireTypeGroup;
using Lab.Infrastructure.Query.Contracts.WireTypeGroup;
using Lab.Presentation.Facade.Contract.WireTypeGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class WireTypeGroupQueryFacade : IWireTypeGroupQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public WireTypeGroupQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditWireTypeGroup GetDetails(Guid guid) => _queryBus.Dispatch<EditWireTypeGroup, Guid>(guid);

        public List<WireTypeGroupViewModel> List() => _queryBus.Dispatch<List<WireTypeGroupViewModel>>();

        public List<WireTypeGroupComboModel> Combo() => _queryBus.Dispatch<List<WireTypeGroupComboModel>>();
    }
}

using Ex.Application.Contracts.GasTypeGroup;
using Lab.Infrastructure.Query.Contracts.GasTypeGroup;
using Lab.Presentation.Facade.Contract.GasTypeGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class GasTypeGroupQueryFacade : IGasTypeGroupQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public GasTypeGroupQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditGasTypeGroup GetDetails(Guid guid) => _queryBus.Dispatch<EditGasTypeGroup, Guid>(guid);

        public List<GasTypeGroupViewModel> List() => _queryBus.Dispatch<List<GasTypeGroupViewModel>>();

        public List<GasTypeGroupComboModel> Combo() => _queryBus.Dispatch<List<GasTypeGroupComboModel>>();
    }
}

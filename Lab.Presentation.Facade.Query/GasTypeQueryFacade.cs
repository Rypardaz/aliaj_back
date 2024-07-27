using Ex.Application.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.GasType;
using Lab.Presentation.Facade.Contract.GasType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class GasTypeQueryFacade : IGasTypeQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public GasTypeQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditGasType GetDetails(Guid guid) => _queryBus.Dispatch<EditGasType, Guid>(guid);

        public List<GasTypeViewModel> List() => _queryBus.Dispatch<List<GasTypeViewModel>>();

        public List<GasTypeComboModel> Combo() => _queryBus.Dispatch<List<GasTypeComboModel>>();
    }
}

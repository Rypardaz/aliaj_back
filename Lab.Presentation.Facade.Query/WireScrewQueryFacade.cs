using Ex.Application.Contracts.WireScrew;
using Lab.Infrastructure.Query.Contracts.WireScrew;
using Lab.Presentation.Facade.Contract.WireScrew;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class WireScrewQueryFacade : IWireScrewQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public WireScrewQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditWireScrew GetDetails(Guid guid) => _queryBus.Dispatch<EditWireScrew, Guid>(guid);

        public List<WireScrewViewModel> List() => _queryBus.Dispatch<List<WireScrewViewModel>>();

        public List<WireScrewComboModel> Combo() => _queryBus.Dispatch<List<WireScrewComboModel>>();
    }
}

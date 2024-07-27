using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Infrastructure.Query.Contracts.PowderTypeGroup;
using Lab.Presentation.Facade.Contract.PowderTypeGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class PowderTypeGroupQueryFacade : IPowderTypeGroupQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public PowderTypeGroupQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditPowderTypeGroup GetDetails(Guid guid) => _queryBus.Dispatch<EditPowderTypeGroup, Guid>(guid);

        public List<PowderTypeGroupViewModel> List() => _queryBus.Dispatch<List<PowderTypeGroupViewModel>>();

        public List<PowderTypeGroupComboModel> Combo() => _queryBus.Dispatch<List<PowderTypeGroupComboModel>>();
    }
}

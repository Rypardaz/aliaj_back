using Ex.Application.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.PartGroup;
using Lab.Presentation.Facade.Contract.PartGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class PartGroupQueryFacade : IPartGroupQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public PartGroupQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditPartGroup GetDetails(Guid guid) => _queryBus.Dispatch<EditPartGroup, Guid>(guid);

        public List<PartGroupViewModel> List() => _queryBus.Dispatch<List<PartGroupViewModel>>();

        public List<PartGroupComboModel> Combo() => _queryBus.Dispatch<List<PartGroupComboModel>>();
    }
}

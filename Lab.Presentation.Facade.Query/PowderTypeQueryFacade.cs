using Ex.Application.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.PowderType;
using Lab.Presentation.Facade.Contract.PowderType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class PowderTypeQueryFacade : IPowderTypeQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public PowderTypeQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditPowderType GetDetails(Guid guid) => _queryBus.Dispatch<EditPowderType, Guid>(guid);

        public List<PowderTypeViewModel> List() => _queryBus.Dispatch<List<PowderTypeViewModel>>();

        public List<PowderTypeComboModel> Combo() => _queryBus.Dispatch<List<PowderTypeComboModel>>();
    }
}

using Ex.Application.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Part;
using Lab.Presentation.Facade.Contract.Part;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class PartQueryFacade : IPartQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public PartQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditPart GetDetails(Guid guid) => _queryBus.Dispatch<EditPart, Guid>(guid);

        public List<PartViewModel> List() => _queryBus.Dispatch<List<PartViewModel>>();

        public List<PartComboModel> Combo(Guid? salonGuid) => _queryBus.Dispatch<List<PartComboModel>, Guid?>(salonGuid);
    }
}

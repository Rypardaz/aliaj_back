using Ex.Application.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Activity;
using Lab.Presentation.Facade.Contract.Activity;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query
{
    public class ActivityQueryFacade : IActivityQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public ActivityQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

        public EditActivity GetDetails(Guid guid) => _queryBus.Dispatch<EditActivity, Guid>(guid);

        public List<ActivityViewModel> List() => _queryBus.Dispatch<List<ActivityViewModel>>();

        public List<ActivityComboModel> Combo(Guid? salonGuid) => 
            _queryBus.Dispatch<List<ActivityComboModel>, Guid?>(salonGuid);
    }
}

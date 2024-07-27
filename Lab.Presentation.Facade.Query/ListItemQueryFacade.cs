using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.ListItem;
using Lab.Infrastructure.Query.Contracts.ListItem;

namespace Lab.Presentation.Facade.Query
{
    public class ListItemQueryFacade : IListItemQueryFacade
    {
        private readonly IQueryBus _queryBus;

        public ListItemQueryFacade(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        public List<ListItemComboModel> GetForCombo(int listGroupId) => _queryBus.Dispatch<List<ListItemComboModel>, int>(listGroupId);
    }
}

using AM.Infrastructure.Query.Contract.ListItem;
using AM.Presentation.Facade.Contract.ListItem;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ListItemQueryFacade(IQueryBus queryBus) : IListItemQueryFacade
{
    public List<ListItemComboModel> GetForCombo(int listGroupId) => queryBus.Dispatch<List<ListItemComboModel>, int>(listGroupId);
}
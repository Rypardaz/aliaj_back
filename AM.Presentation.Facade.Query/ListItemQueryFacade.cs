using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.ListItem;
using Lab.Infrastructure.Query.Contracts.ListItem;

namespace Lab.Presentation.Facade.Query;

public class ListItemQueryFacade(IQueryBus queryBus) : IListItemQueryFacade
{
    public List<ListItemComboModel> GetForCombo(int listGroupId) => queryBus.Dispatch<List<ListItemComboModel>, int>(listGroupId);
}
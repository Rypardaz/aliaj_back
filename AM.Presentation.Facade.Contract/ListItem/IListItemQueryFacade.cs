using AM.Infrastructure.Query.Contract.ListItem;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ListItem;

public interface IListItemQueryFacade : IFacadeService
{
    List<ListItemComboModel> GetForCombo(int listGroupId);
}
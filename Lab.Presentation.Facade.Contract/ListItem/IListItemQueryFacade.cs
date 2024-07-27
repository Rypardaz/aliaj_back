using Lab.Infrastructure.Query.Contracts.ListItem;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.ListItem
{
    public interface IListItemQueryFacade : IFacadeService
    {
        List<ListItemComboModel> GetForCombo(int listGroupId);
    }
}

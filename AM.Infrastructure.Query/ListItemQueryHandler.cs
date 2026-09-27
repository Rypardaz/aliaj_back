using AM.Infrastructure.Query.Contract.ListItem;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class ListItemQueryHandler(BaseDapperRepository dapper) : IQueryHandler<List<ListItemComboModel>, int>
{
    public List<ListItemComboModel> Handle(int listGroupId) =>
        dapper.Select<ListItemComboModel>(
            $"SELECT Id, Title = Name, Guid, Code FROM tbListItem WHERE ListGroupId = {listGroupId}");
}
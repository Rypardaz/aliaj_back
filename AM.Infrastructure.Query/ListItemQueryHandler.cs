using PhoenixFramework.Dapper;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.ListItem;

namespace Lab.Infrastructure.Query;

public class ListItemQueryHandler(BaseDapperRepository dapper) : IQueryHandler<List<ListItemComboModel>, int>
{
    public List<ListItemComboModel> Handle(int listGroupId) =>
        dapper.Select<ListItemComboModel>(
            $"SELECT Id, Title = Name, Guid, Code FROM tbListItem WHERE ListGroupId = {listGroupId}");
}
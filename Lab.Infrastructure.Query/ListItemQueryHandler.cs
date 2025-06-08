using PhoenixFramework.Dapper;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.ListItem;

namespace Lab.Infrastructure.Query;

public class ListItemQueryHandler : IQueryHandler<List<ListItemComboModel>, int>
{
    private readonly BaseDapperRepository _dapper;

    public ListItemQueryHandler(BaseDapperRepository dapper)
    {
        _dapper = dapper;
    }

    public List<ListItemComboModel> Handle(int listGroupId) =>
        _dapper.Select<ListItemComboModel>(
            $"SELECT Id, Title = Name, Guid, Code FROM tbListItem WHERE ListGroupId = {listGroupId}");
}
using PhoenixFramework.Domain;

namespace AM.Domain.ListItemAgg;

public class ListItem : AggregateRootBase<int>
{
    public int ListGroupId { get; private set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
}
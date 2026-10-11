using PhoenixFramework.Domain;

namespace AM.Domain.RegionAgg;

public class Region : AggregateRootBase<int>
{
    public int ParentId { get; private set; }
    public string Name { get; private set; }
}
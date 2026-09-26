using Ex.Domain.WireTypeAgg;
using PhoenixFramework.Domain;

namespace Ex.Domain.ProjectAgg;

public class ProjectReplacementWireType : EntityBase<long>
{
    public long ProjectId { get; private set; }
    public long WireTypeId { get; private set; }
    public Project Project { get; private set; }
    public WireType WireType { get; private set; }

    protected ProjectReplacementWireType()
    {
    }

    public ProjectReplacementWireType(Guid creator, long projectId, long wireTypeId) : base(creator)
    {
        ProjectId = projectId;
        WireTypeId = wireTypeId;
    }
}
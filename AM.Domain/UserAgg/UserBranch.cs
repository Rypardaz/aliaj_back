using PhoenixFramework.Domain;

namespace Ex.Domain.UserAgg;

public record UserBranch : ValueObjectBase
{
    public int BranchId { get; set; }
}
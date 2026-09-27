using PhoenixFramework.Domain;

namespace AM.Domain.UserAgg;

public record UserBranch : ValueObjectBase
{
    public int BranchId { get; set; }
}
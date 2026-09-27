using PhoenixFramework.Core;

namespace AM.Domain.PowderTypeGroupAgg.Service;

public interface IPowderTypeGroupService : IDomainService
{
    void ThrowWhenDuplicatedName(string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
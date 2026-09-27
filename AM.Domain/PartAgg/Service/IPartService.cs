using PhoenixFramework.Core;

namespace AM.Domain.PartAgg.Service;

public interface IPartService : IDomainService
{
    void ThrowWhenDuplicatedName(long partGroupId, string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
using PhoenixFramework.Core;

namespace AM.Domain.GasTypeAgg.Service;

public interface IGasTypeService : IDomainService
{
    void ThrowWhenDuplicatedName(long gasTypeGroupId, string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
using PhoenixFramework.Core;

namespace AM.Domain.MaterialAgg.Service;

public interface IMaterialService : IDomainService
{
    void ThrowWhenDuplicatedCode(string name, long? id = null);
    void ThrowWhenDuplicatedName(string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
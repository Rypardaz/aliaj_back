using PhoenixFramework.Core;

namespace AM.Domain.Material.Service;

public interface IMaterialService : IDomainService
{
    void ThrowWhenDuplicatedCode(string name, long? id = null);
    void ThrowWhenDuplicatedName(string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
using PhoenixFramework.Core;

namespace AM.Domain.UnitAgg.Service;

public interface IUnitService : IDomainService
{
    void ThrowWhenDuplicatedCode(string name, long? id = null);
    void ThrowWhenDuplicatedName(string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
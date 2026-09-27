using PhoenixFramework.Core;

namespace AM.Domain.SalonAgg.Service;

public interface ISalonService : IDomainService
{
    void ThrowWhenDuplicatedName(string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
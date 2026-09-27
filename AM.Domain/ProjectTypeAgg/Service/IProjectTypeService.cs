using PhoenixFramework.Core;

namespace AM.Domain.ProjectTypeAgg.Service;

public interface IProjectTypeService : IDomainService
{
    void ThrowWhenDuplicatedName(long salonId, string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
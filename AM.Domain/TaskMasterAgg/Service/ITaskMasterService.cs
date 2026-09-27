using PhoenixFramework.Core;

namespace AM.Domain.TaskMasterAgg.Service;

public interface ITaskMasterService : IDomainService
{
    void ThrowWhenDuplicatedName(string name, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
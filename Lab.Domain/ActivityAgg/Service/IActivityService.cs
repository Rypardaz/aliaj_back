using PhoenixFramework.Core;

namespace Ex.Domain.ActivityAgg.Service
{
    public interface IActivityService : IDomainService
    {
        void ThrowWhenDuplicatedName(string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

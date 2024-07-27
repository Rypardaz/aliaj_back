using PhoenixFramework.Core;

namespace Ex.Domain.PartGroupAgg.Service
{
    public interface IPartGroupService : IDomainService
    {
        void ThrowWhenDuplicatedName(string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

using PhoenixFramework.Core;

namespace Ex.Domain.GasTypeGroupAgg.Service
{
    public interface IGasTypeGroupService : IDomainService
    {
        void ThrowWhenDuplicatedName(string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

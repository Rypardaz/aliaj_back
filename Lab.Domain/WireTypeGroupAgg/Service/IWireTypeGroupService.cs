using PhoenixFramework.Core;

namespace Ex.Domain.WireTypeGroupAgg.Service
{
    public interface IWireTypeGroupService : IDomainService
    {
        void ThrowWhenDuplicatedName(string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

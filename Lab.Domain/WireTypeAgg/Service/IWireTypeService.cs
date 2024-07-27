using PhoenixFramework.Core;

namespace Ex.Domain.WireTypeAgg.Service
{
    public interface IWireTypeService : IDomainService
    {
        void ThrowWhenDuplicatedName(long wireTypeGroupId, string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

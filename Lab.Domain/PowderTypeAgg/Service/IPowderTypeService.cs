using PhoenixFramework.Core;

namespace Ex.Domain.PowderTypeAgg.Service
{
    public interface IPowderTypeService : IDomainService
    {
        void ThrowWhenDuplicatedName(long powderTypeGroupId, string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

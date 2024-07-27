using PhoenixFramework.Core;

namespace Ex.Domain.ProjectTypeAgg.Service
{
    public interface IProjectTypeService : IDomainService
    {
        void ThrowWhenDuplicatedName(long salonId, string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

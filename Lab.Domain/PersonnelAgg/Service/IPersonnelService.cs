using PhoenixFramework.Core;

namespace Ex.Domain.PersonnelAgg.Service
{
    public interface IPersonnelService : IDomainService
    {
        void ThrowWhenDuplicatedName(string name, string family, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

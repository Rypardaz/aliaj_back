using PhoenixFramework.Core;


namespace Ex.Domain.SalonAgg.Service
{
    public interface ISalonService : IDomainService
    {
        void ThrowWhenDuplicatedName(string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

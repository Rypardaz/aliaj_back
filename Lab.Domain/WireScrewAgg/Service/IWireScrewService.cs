using PhoenixFramework.Core;

namespace Ex.Domain.WireScrewAgg.Service
{
    public interface IWireScrewService : IDomainService
    {
        void ThrowWhenDuplicatedScrew(long wireTypeId, int screw, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

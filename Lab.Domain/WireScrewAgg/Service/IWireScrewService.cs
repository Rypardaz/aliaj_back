using PhoenixFramework.Core;

namespace Ex.Domain.WireScrewAgg.Service
{
    public interface IWireScrewService : IDomainService
    {
        void ThrowWhenDuplicatedScrew( int screw, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

using PhoenixFramework.Core;

namespace Ex.Domain.MachineAgg.Service
{
    public interface IMachineService : IDomainService
    {
        void ThrowWhenDuplicatedCode(string code, long? id = null);
        void ThrowWhenDuplicatedName(string name, long? id = null);
        void ThrowWhenRecordNotFound(long id);
    }
}

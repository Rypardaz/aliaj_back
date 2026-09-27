using PhoenixFramework.Domain;

namespace AM.Domain.MachineLogAgg;

public interface IMachineLogRepository : IRepository<long, MachineLog>
{

}
using PhoenixFramework.Domain;

namespace AM.Domain.MachineAgg;

public interface IMachineRepository : IRepository<long, Machine>
{
    long GetIdBy(string code);
}
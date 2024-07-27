using PhoenixFramework.Domain;

namespace Ex.Domain.MachineAgg
{
    public interface IMachineRepository : IRepository<long, Machine>
    {
        long GetIdBy(string code);
    }
}

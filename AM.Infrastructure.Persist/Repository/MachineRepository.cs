using AM.Domain.MachineAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class MachineRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Machine>(aliajCommandContext), IMachineRepository
{
    public long GetIdBy(string code)
    {
        return aliajCommandContext.Machine
            .Select(x => new { x.Id, x.Code })
            .First(x => x.Code == code)
            .Id;
    }
}
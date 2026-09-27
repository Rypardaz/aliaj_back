using AM.Domain.MachineLogAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class MachineLogRepository(AliajCommandContext context)
    : BaseRepository<long, MachineLog>(context), IMachineLogRepository;
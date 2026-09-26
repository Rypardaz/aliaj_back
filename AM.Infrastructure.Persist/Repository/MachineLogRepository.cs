using Ex.Domain.MachineLogAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class MachineLogRepository(AliajCommandContext context)
    : BaseRepository<long, MachineLog>(context), IMachineLogRepository;
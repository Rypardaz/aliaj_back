using AM.Domain.TaskMasterAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class TaskMasterRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, TaskMaster>(aliajCommandContext), ITaskMasterRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
using AM.Domain.ActivityAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class ActivityRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Activity>(aliajCommandContext), IActivityRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
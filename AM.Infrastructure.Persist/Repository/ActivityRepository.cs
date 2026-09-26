using Ex.Domain.ActivityAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class ActivityRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Activity>(aliajCommandContext), IActivityRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
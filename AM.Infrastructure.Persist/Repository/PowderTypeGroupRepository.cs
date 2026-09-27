using AM.Domain.PowderTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class PowderTypeGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, PowderTypeGroup>(aliajCommandContext), IPowderTypeGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
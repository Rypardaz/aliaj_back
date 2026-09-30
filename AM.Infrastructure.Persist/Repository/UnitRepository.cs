using AM.Domain.UnitAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class UnitRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Unit>(aliajCommandContext), IUnitRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
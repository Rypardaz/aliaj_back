using AM.Domain.PowderTypeAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class PowderTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, PowderType>(aliajCommandContext), IPowderTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
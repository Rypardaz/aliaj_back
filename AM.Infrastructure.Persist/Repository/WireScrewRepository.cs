using AM.Domain.WireScrewAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class WireScrewRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, WireScrew>(aliajCommandContext), IWireScrewRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
using Ex.Domain.WireScrewAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class WireScrewRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, WireScrew>(aliajCommandContext), IWireScrewRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
using AM.Domain.WireTypeAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class WireTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, WireType>(aliajCommandContext), IWireTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
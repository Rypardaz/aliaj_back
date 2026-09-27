using AM.Domain.WireTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class WireTypeGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, WireTypeGroup>(aliajCommandContext), IWireTypeGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
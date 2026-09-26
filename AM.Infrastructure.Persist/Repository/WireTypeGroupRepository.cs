using Ex.Domain.WireTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class WireTypeGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, WireTypeGroup>(aliajCommandContext), IWireTypeGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
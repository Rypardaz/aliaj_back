using Ex.Domain.WireTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class WireTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, WireType>(aliajCommandContext), IWireTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
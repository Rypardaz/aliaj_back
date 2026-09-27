using AM.Domain.GasTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class GasTypeGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, GasTypeGroup>(aliajCommandContext), IGasTypeGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
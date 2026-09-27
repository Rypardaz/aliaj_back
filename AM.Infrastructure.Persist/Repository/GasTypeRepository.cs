using AM.Domain.GasTypeAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class GasTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, GasType>(aliajCommandContext), IGasTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
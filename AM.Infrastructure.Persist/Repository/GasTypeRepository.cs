using Ex.Domain.GasTypeAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class GasTypeRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, GasType>(aliajCommandContext), IGasTypeRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
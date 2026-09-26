using Ex.Domain.GasTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class GasTypeGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, GasTypeGroup>(aliajCommandContext), IGasTypeGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
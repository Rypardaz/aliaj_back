using Ex.Domain.PowderTypeGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class PowderTypeGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, PowderTypeGroup>(aliajCommandContext), IPowderTypeGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
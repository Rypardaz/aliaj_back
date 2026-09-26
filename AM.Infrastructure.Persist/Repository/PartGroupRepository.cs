using Ex.Domain.PartGroupAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class PartGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, PartGroup>(aliajCommandContext), IPartGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
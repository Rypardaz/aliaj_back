using AM.Domain.PartGroupAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class PartGroupRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, PartGroup>(aliajCommandContext), IPartGroupRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
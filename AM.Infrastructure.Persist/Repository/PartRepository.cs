using AM.Domain.PartAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class PartRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Part>(aliajCommandContext), IPartRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
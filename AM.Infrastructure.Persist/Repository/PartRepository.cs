using Ex.Domain.PartAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class PartRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Part>(aliajCommandContext), IPartRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
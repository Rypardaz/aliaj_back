using AM.Domain.MaterialAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class MaterialRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Material>(aliajCommandContext), IMaterialRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
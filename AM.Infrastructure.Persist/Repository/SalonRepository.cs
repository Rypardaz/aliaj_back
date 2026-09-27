using AM.Domain.SalonAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class SalonRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Salon>(aliajCommandContext), ISalonRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
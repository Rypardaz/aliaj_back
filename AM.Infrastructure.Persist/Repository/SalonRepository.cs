using Ex.Domain.SalonAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class SalonRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Salon>(aliajCommandContext), ISalonRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
using AM.Domain.PersonnelAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class PersonnelRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Personnel>(aliajCommandContext), IPersonnelRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
using Ex.Domain.PersonnelAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class PersonnelRepository(AliajCommandContext aliajCommandContext)
    : BaseRepository<long, Personnel>(aliajCommandContext), IPersonnelRepository
{
    private readonly AliajCommandContext _context = aliajCommandContext;
}
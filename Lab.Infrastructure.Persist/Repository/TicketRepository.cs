using Ex.Domain.TicketAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class TicketRepository : BaseRepository<long, Ticket>, ITicketRepository
{
    public TicketRepository(LaboratoryCommandContext context) : base(context)
    {
    }
}
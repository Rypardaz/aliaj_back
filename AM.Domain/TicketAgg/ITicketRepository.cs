using PhoenixFramework.Domain;

namespace AM.Domain.TicketAgg;

public interface ITicketRepository : IRepository<long, Ticket>
{
    
}
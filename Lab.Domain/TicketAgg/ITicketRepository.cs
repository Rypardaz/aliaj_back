using PhoenixFramework.Domain;

namespace Ex.Domain.TicketAgg;

public interface ITicketRepository : IRepository<long, Ticket>
{
    
}
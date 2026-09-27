using AM.Domain.TicketAgg;
using PhoenixFramework.EntityFramework;

namespace AM.Infrastructure.Persist.Repository;

public class TicketRepository(AliajCommandContext context) : BaseRepository<long, Ticket>(context), ITicketRepository;
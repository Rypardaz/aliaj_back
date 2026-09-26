using Ex.Domain.TicketAgg;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class TicketRepository(AliajCommandContext context) : BaseRepository<long, Ticket>(context), ITicketRepository;
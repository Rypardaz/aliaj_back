using AM.Application.Contracts.Ticket;
using AM.Infrastructure.Query.Contract.Ticket;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Ticket;

public interface ITicketQueryFacade : IFacadeService
{
    List<TicketViewModel> GetList(TicketSearchModel searchModel);
    CreateTicket GetForEdit(Guid guid);
}
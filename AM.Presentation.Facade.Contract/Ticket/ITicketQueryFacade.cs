using Ex.Application.Contracts.Ticket;
using Lab.Infrastructure.Query.Contracts.Ticket;
using PhoenixFramework.Core;

namespace Lab.Presentation.Facade.Contract.Ticket;

public interface ITicketQueryFacade : IFacadeService
{
    List<TicketViewModel> GetList(TicketSearchModel searchModel);
    CreateTicket GetForEdit(Guid guid);
}
using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.Ticket;
using Lab.Infrastructure.Query.Contracts.Ticket;

namespace Lab.Presentation.Facade.Query;

public class TicketQueryFacade(IQueryBus queryBus) : ITicketQueryFacade
{
    public List<TicketViewModel> GetList(TicketSearchModel searchModel) =>
        queryBus.Dispatch<List<TicketViewModel>, TicketSearchModel>(searchModel);

    public CreateTicket GetForEdit(Guid guid) => queryBus.Dispatch<CreateTicket, Guid>(guid);
}
using AM.Application.Contracts.Ticket;
using AM.Infrastructure.Query.Contract.Ticket;
using AM.Presentation.Facade.Contract.Ticket;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class TicketQueryFacade(IQueryBus queryBus) : ITicketQueryFacade
{
    public List<TicketViewModel> GetList(TicketSearchModel searchModel) =>
        queryBus.Dispatch<List<TicketViewModel>, TicketSearchModel>(searchModel);

    public CreateTicket GetForEdit(Guid guid) => queryBus.Dispatch<CreateTicket, Guid>(guid);
}
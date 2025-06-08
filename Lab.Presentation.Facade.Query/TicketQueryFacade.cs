using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Query;
using Lab.Presentation.Facade.Contract.Ticket;
using Lab.Infrastructure.Query.Contracts.Ticket;

namespace Lab.Presentation.Facade.Query;

public class TicketQueryFacade : ITicketQueryFacade
{
    private readonly IQueryBus _queryBus;

    public TicketQueryFacade(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    public List<TicketViewModel> GetList(TicketSearchModel searchModel) =>
        _queryBus.Dispatch<List<TicketViewModel>, TicketSearchModel>(searchModel);

    public CreateTicket GetForEdit(Guid guid) => _queryBus.Dispatch<CreateTicket, Guid>(guid);
}
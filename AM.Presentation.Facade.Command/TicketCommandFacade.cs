using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Command;
using Lab.Presentation.Facade.Contract.Ticket;

namespace Lab.Presentation.Facade.Command;

public class TicketCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    : ITicketCommandFacade
{
    public Guid Create(CreateTicket command) => responsiveCommandBus.Dispatch<CreateTicket, Guid>(command);

    public void AddResponse(AddResponse command) => commandBus.Dispatch(command);
    public void Delete(Guid guid) => commandBus.Dispatch(new DeleteTicket(guid));
}
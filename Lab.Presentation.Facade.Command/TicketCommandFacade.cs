using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Command;
using Lab.Presentation.Facade.Contract.Ticket;

namespace Lab.Presentation.Facade.Command;

public class TicketCommandFacade : ITicketCommandFacade
{
    private readonly ICommandBus _commandBus;
    private readonly IResponsiveCommandBus _responsiveCommandBus;

    public TicketCommandFacade(ICommandBus commandBus, IResponsiveCommandBus responsiveCommandBus)
    {
        _commandBus = commandBus;
        _responsiveCommandBus = responsiveCommandBus;
    }

    public Guid Create(CreateTicket command) => _responsiveCommandBus.Dispatch<CreateTicket, Guid>(command);

    public void AddResponse(AddResponse command) => _commandBus.Dispatch(command);
    public void Delete(Guid guid) => _commandBus.Dispatch(new DeleteTicket(guid));
}
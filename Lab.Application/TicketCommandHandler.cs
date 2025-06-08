using Ex.Domain.TicketAgg;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Command;

namespace Ex.Application;

public class TicketCommandHandler :
    ICommandHandler<CreateTicket, Guid>,
    ICommandHandler<AddResponse>,
    ICommandHandler<DeleteTicket>
{
    private readonly IClaimHelper _claimHelper;
    private readonly ITicketRepository _ticketRepository;

    public TicketCommandHandler(ITicketRepository ticketRepository, IClaimHelper claimHelper)
    {
        _ticketRepository = ticketRepository;
        _claimHelper = claimHelper;
    }

    public Guid Handle(CreateTicket command)
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        var ticket = new Ticket(currentUserGuid, currentUserGuid, command.ToUserGuid, command.Message);
        _ticketRepository.Create(ticket);
        return ticket.Guid;
    }

    public void Handle(AddResponse command)
    {
        var ticket = _ticketRepository.Load(command.Guid);
        ticket.AddResponse(command.Response);
        _ticketRepository.Update(ticket);
    }

    public void Handle(DeleteTicket command)
    {
        var ticket = _ticketRepository.Load(command.Guid);
        _ticketRepository.Delete(ticket);
    }
}
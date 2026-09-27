using AM.Application.Contracts.Ticket;
using AM.Domain.TicketAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class TicketCommandHandler(ITicketRepository ticketRepository, IClaimHelper claimHelper)
    :
        ICommandHandler<CreateTicket, Guid>,
        ICommandHandler<AddResponse>,
        ICommandHandler<DeleteTicket>
{
    public Guid Handle(CreateTicket command)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var ticket = new Ticket(currentUserGuid, currentUserGuid, command.ToUserGuid, command.Message);
        ticketRepository.Create(ticket);
        return ticket.Guid;
    }

    public void Handle(AddResponse command)
    {
        var ticket = ticketRepository.Load(command.Guid);
        ticket.AddResponse(command.Response);
        ticketRepository.Update(ticket);
    }

    public void Handle(DeleteTicket command)
    {
        var ticket = ticketRepository.Load(command.Guid);
        ticketRepository.Delete(ticket);
    }
}
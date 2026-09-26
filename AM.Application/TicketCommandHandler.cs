using Ex.Domain.TicketAgg;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Command;

namespace Ex.Application;

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
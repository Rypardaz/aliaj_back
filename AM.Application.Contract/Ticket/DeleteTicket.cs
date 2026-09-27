using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Ticket;

public class DeleteTicket(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
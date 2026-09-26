using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Ticket;

public class DeleteTicket(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
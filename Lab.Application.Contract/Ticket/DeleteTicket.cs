using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Ticket;

public class DeleteTicket : ICommand
{
    public Guid Guid { get; set; }

    public DeleteTicket(Guid guid)
    {
        Guid = guid;
    }
}
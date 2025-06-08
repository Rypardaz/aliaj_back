using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Ticket;

public class CreateTicket : ICommand
{
    public Guid ToUserGuid { get; set; }
    public string Message { get; set; }
}
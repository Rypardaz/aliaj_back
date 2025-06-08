using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Ticket;

public class AddResponse : ICommand
{
    public Guid Guid { get; set; }
    public string Response { get; set; }
}
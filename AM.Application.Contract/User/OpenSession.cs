using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.User;

public class OpenSession : ICommand
{
    public Guid Guid { get; set; }
    public bool IsSuccessful { get; set; }
    public string? ClientIpAddress { get; set; }
}
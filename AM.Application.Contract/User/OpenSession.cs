using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.User;

public class OpenSession : ICommand
{
    public Guid Guid { get; set; }
    public bool IsSuccessful { get; set; }
    public string? ClientIpAddress { get; set; }
}
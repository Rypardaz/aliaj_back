using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.User;

public class Login : ICommand
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string DbName { get; set; }
}
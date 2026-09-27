using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.User;

public class ChangePassword : ICommand
{
    public int UserId { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}
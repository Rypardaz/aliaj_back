namespace Ex.Application.Contracts.User;

public class ChangePassword
{
    public int UserId { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
}
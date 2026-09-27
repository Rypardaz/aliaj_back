using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.User;

public class DeleteUser(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}

public class LockUser(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}

public class UnlockUser(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
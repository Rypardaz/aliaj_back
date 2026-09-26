using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Personnel;

public class RemovePersonnel(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Personnel;

public class DeactivatePersonnel(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
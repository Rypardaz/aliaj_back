using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Personnel;

public class ActivatePersonnel(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
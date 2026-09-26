using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Part;

public class ActivatePart(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
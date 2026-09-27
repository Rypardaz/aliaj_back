using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Part;

public class DeactivatePart(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
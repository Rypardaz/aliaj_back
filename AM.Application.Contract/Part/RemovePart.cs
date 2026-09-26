using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Part;

public class RemovePart(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
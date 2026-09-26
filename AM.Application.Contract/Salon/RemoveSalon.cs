using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Salon;

public class RemoveSalon(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
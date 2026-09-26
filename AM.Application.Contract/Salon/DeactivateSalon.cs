using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Salon;

public class DeactivateSalon(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
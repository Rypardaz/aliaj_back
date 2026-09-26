using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Salon;

public class ActivateSalon(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
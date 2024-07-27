using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Salon
{
    public class DeactivateSalon : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateSalon(Guid guid)
        {
            Guid = guid;
        }
    }
}

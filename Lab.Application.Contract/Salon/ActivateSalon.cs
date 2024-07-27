using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Salon
{
    public class ActivateSalon : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateSalon(Guid guid)
        {
            Guid = guid;
        }
    }
}

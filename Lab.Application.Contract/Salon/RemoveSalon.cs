using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Salon
{
    public class RemoveSalon : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveSalon(Guid guid)
        {
            Guid = guid;
        }
    }
}

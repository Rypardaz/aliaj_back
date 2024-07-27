using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasType
{
    public class DeactivateGasType : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateGasType(Guid guid)
        {
            Guid = guid;
        }
    }
}

using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasType
{
    public class ActivateGasType : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateGasType(Guid guid)
        {
            Guid = guid;
        }
    }
}

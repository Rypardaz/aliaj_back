using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasType
{
    public class RemoveGasType : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveGasType(Guid guid)
        {
            Guid = guid;
        }
    }
}

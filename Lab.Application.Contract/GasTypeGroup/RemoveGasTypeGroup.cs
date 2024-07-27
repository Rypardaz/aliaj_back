using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasTypeGroup
{
    public class RemoveGasTypeGroup : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveGasTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }
}

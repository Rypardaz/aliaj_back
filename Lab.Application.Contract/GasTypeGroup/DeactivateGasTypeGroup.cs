using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasTypeGroup
{
    public class DeactivateGasTypeGroup : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateGasTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }
}

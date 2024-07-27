using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.GasTypeGroup
{
    public class ActivateGasTypeGroup : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateGasTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }
}

using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderTypeGroup
{
    public class DeactivatePowderTypeGroup : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivatePowderTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }

}

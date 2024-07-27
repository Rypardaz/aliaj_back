using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderTypeGroup
{
    public class ActivatePowderTypeGroup : ICommand
    {
        public Guid Guid { get; set; }

        public ActivatePowderTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }

}

using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderTypeGroup
{
    public class RemovePowderTypeGroup : ICommand
    {
        public Guid Guid { get; set; }
        public RemovePowderTypeGroup(Guid guid)
        {
            Guid = guid;
        }
    }

}

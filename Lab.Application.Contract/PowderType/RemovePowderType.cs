using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderType
{
    public class RemovePowderType : ICommand
    {
        public Guid Guid { get; set; }
        public RemovePowderType(Guid guid)
        {
            Guid = guid;
        }
    }
}

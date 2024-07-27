using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderType
{
    public class ActivatePowderType : ICommand
    {
        public Guid Guid { get; set; }

        public ActivatePowderType(Guid guid)
        {
            Guid = guid;
        }
    }
}

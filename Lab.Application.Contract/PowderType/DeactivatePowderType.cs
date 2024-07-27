using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PowderType
{
    public class DeactivatePowderType : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivatePowderType(Guid guid)
        {
            Guid = guid;
        }
    }
}

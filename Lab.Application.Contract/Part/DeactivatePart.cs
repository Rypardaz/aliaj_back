using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Part
{
    public class DeactivatePart : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivatePart(Guid guid)
        {
            Guid = guid;
        }
    }
}

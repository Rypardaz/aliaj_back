using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Part
{
    public class ActivatePart : ICommand
    {
        public Guid Guid { get; set; }

        public ActivatePart(Guid guid)
        {
            Guid = guid;
        }
    }
}

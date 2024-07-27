using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Part
{
    public class RemovePart : ICommand
    {
        public Guid Guid { get; set; }
        public RemovePart(Guid guid)
        {
            Guid = guid;
        }
    }
}

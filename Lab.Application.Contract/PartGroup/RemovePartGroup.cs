using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PartGroup
{
    public class RemovePartGroup : ICommand
    {
        public Guid Guid { get; set; }
        public RemovePartGroup(Guid guid)
        {
            Guid = guid;
        }
    }
}

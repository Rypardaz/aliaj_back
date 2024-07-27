using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PartGroup
{
    public class DeactivatePartGroup : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivatePartGroup(Guid guid)
        {
            Guid = guid;
        }
    }
}

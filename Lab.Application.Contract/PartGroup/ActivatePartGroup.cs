using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.PartGroup
{
    public class ActivatePartGroup : ICommand
    {
        public Guid Guid { get; set; }

        public ActivatePartGroup(Guid guid)
        {
            Guid = guid;
        }
    }
}

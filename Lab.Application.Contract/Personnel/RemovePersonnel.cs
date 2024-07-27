using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Personnel
{
    public class RemovePersonnel : ICommand
    {
        public Guid Guid { get; set; }
        public RemovePersonnel(Guid guid)
        {
            Guid = guid;
        }
    }
}

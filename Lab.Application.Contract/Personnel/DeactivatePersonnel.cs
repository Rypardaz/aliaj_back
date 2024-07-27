using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Personnel
{
    public class DeactivatePersonnel : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivatePersonnel(Guid guid)
        {
            Guid = guid;
        }
    }
}

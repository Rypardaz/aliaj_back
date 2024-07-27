using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Personnel
{
    public class ActivatePersonnel : ICommand
    {
        public Guid Guid { get; set; }

        public ActivatePersonnel(Guid guid)
        {
            Guid = guid;
        }
    }
}

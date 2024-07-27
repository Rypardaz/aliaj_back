using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Activity
{
    public class DeactivateActivity : ICommand
    {
        public Guid Guid { get; set; }

        public DeactivateActivity(Guid guid)
        {
            Guid = guid;
        }
    }
}

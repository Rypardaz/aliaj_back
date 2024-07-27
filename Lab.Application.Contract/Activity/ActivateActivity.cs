using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Activity
{
    public class ActivateActivity : ICommand
    {
        public Guid Guid { get; set; }

        public ActivateActivity(Guid guid)
        {
            Guid = guid;
        }
    }
}

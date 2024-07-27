using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.Activity
{
    public class RemoveActivity : ICommand
    {
        public Guid Guid { get; set; }
        public RemoveActivity(Guid guid)
        {
            Guid = guid;
        }
    }
}

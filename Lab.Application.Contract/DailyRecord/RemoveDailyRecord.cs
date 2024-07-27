using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.DailyRecord
{
    public class RemoveDailyRecord : ICommand
    {
        public Guid Guid { get; set; }
    }
}

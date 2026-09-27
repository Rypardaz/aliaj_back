using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.DailyRecord;

public class RemoveDailyRecord : ICommand
{
    public Guid Guid { get; set; }
}
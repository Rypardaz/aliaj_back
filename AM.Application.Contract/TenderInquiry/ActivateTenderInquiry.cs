using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.TenderInquiry;

public class ActivateTenderInquiry(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}

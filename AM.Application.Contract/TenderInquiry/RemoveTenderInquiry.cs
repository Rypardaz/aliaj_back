using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.TenderInquiry;

public class RemoveTenderInquiry(Guid guid) : ICommand
{
    public Guid Guid { get; set; } = guid;
}
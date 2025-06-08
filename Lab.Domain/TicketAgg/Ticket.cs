using PhoenixFramework.Domain;

namespace Ex.Domain.TicketAgg;

public class Ticket : AggregateRootBase<long>
{
    public Guid FromUserGuid { get; private set; }
    public Guid ToUserGuid { get; private set; }
    public string Message { get; private set; }
    public string? Response { get; private set; }

    public Ticket()
    {
    }

    public Ticket(Guid creator, Guid fromUserGuid, Guid toUserGuid, string message) : base(creator)
    {
        FromUserGuid = fromUserGuid;
        ToUserGuid = toUserGuid;
        Message = message;
    }

    public void AddResponse(string response)
    {
        Response = response;
    }
}
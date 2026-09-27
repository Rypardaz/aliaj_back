using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.Ticket;

public class TicketViewModel : ViewModelAbilities
{
    public string FromUserFullname { get; set; }
    public string ToUserFullname { get; set; }
    public string Message { get; set; }
    public string Response { get; set; }
}
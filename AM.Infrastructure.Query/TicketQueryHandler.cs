using AM.Application.Contracts.Ticket;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.Shared;
using AM.Infrastructure.Query.Contract.Ticket;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;
using PhoenixFramework.Identity;

namespace AM.Infrastructure.Query;

public class TicketQueryHandler(AliajQueryContext context, IClaimHelper claimHelper, BaseDapperRepository dapper)
    :
        IQueryHandler<List<TicketViewModel>, TicketSearchModel>,
        IQueryHandler<CreateTicket, Guid>
{
    private readonly AliajQueryContext _context = context;

    public List<TicketViewModel> Handle(TicketSearchModel searchModel)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        return dapper.SelectFromSp<TicketViewModel>(QueryConstants.GetTicketFor, new
        {
            searchModel.Type,
            UserGuid = currentUserGuid
        });
    }

    public CreateTicket Handle(Guid guid)
    {
        return dapper.SelectFromSpFirstOrDefault<CreateTicket>(QueryConstants.GetTicketFor, new
        {
            Type = QueryTypes.List,
            Guid = guid
        });
    }
}
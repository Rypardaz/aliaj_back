using PhoenixFramework.Dapper;
using PhoenixFramework.Identity;
using Lab.Infrastructure.Persist;
using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.Ticket;

namespace Lab.Infrastructure.Query;

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
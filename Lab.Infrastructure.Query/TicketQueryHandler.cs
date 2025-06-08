using PhoenixFramework.Dapper;
using PhoenixFramework.Identity;
using Lab.Infrastructure.Persist;
using Ex.Application.Contracts.Ticket;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.Ticket;

namespace Lab.Infrastructure.Query;

public class TicketQueryHandler :
    IQueryHandler<List<TicketViewModel>, TicketSearchModel>,
    IQueryHandler<CreateTicket, Guid>
{
    private readonly LaboratoryQueryContext _context;
    private readonly IClaimHelper _claimHelper;
    private readonly BaseDapperRepository _dapper;

    public TicketQueryHandler(LaboratoryQueryContext context, IClaimHelper claimHelper, BaseDapperRepository dapper)
    {
        _context = context;
        _claimHelper = claimHelper;
        _dapper = dapper;
    }

    public List<TicketViewModel> Handle(TicketSearchModel searchModel)
    {
        var currentUserGuid = _claimHelper.GetCurrentUserGuid();
        return _dapper.SelectFromSp<TicketViewModel>(QueryConstants.GetTicketFor, new
        {
            searchModel.Type,
            UserGuid = currentUserGuid
        });
    }

    public CreateTicket Handle(Guid guid)
    {
        return _dapper.SelectFromSpFirstOrDefault<CreateTicket>(QueryConstants.GetTicketFor, new
        {
            Type = QueryTypes.List,
            Guid = guid
        });
    }
}
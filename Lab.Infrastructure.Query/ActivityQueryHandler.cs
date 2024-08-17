using PhoenixFramework.Dapper;
using Ex.Application.Contracts.Activity;
using Lab.Infrastructure.Persist;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Shared;

namespace Lab.Infrastructure.Query;

public class ActivityQueryHandler :
    IQueryHandler<List<ActivityViewModel>>,
    IQueryHandler<EditActivity, Guid>,
    IQueryHandler<List<ActivityComboModel>, Guid?>
{
    private readonly BaseDapperRepository _dapperRepository;
    private readonly LaboratoryQueryContext _context;

    public ActivityQueryHandler(BaseDapperRepository dapperRepository,
        LaboratoryQueryContext context)
    {
        _dapperRepository = dapperRepository;
        _context = context;
    }

    List<ActivityViewModel> IQueryHandler<List<ActivityViewModel>>.Handle() =>
        _dapperRepository.SelectFromSp<ActivityViewModel>(QueryConstants.GetActivityFor, new
        {
            Type = QueryTypes.List
        });

    public EditActivity Handle(Guid guid)
    {
        var activity = _dapperRepository.SelectFromSpFirstOrDefault<EditActivity>(QueryConstants.GetActivityFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

        activity.SalonGuids = _context.ActivitySalons
            .Where(x => x.Activity.Guid == activity.Guid)
            .Select(x => x.Salon.Guid)
            .ToList();

        return activity;
    }

    public List<ActivityComboModel> Handle(Guid? salonGuid)
    {
        return _dapperRepository.SelectFromSp<ActivityComboModel>(QueryConstants.GetActivityFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }
}
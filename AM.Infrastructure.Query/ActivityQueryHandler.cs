using PhoenixFramework.Dapper;
using Ex.Application.Contracts.Activity;
using Lab.Infrastructure.Persist;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Shared;

namespace Lab.Infrastructure.Query;

public class ActivityQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<ActivityViewModel>>,
    IQueryHandler<EditActivity, Guid>,
    IQueryHandler<List<ActivityComboModel>, Guid?>
{
    List<ActivityViewModel> IQueryHandler<List<ActivityViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<ActivityViewModel>(QueryConstants.GetActivityFor, new
        {
            Type = QueryTypes.List
        });

    public EditActivity Handle(Guid guid)
    {
        var activity = dapperRepository.SelectFromSpFirstOrDefault<EditActivity>(QueryConstants.GetActivityFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

        activity.SalonGuids = context.ActivitySalons
            .Where(x => x.Activity.Guid == activity.Guid)
            .Select(x => x.Salon.Guid)
            .ToList();

        return activity;
    }

    public List<ActivityComboModel> Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<ActivityComboModel>(QueryConstants.GetActivityFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }
}
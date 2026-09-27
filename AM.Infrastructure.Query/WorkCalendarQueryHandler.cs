using AM.Infrastructure.Query.Contract.WorkCalendar;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class WorkCalendarQueryHandler(BaseDapperRepository repository)
    : IQueryHandler<List<WorkCalendarViewModel>, WorkCalendarSearchModel>
{
    public List<WorkCalendarViewModel> Handle(WorkCalendarSearchModel searchModel)
    {
        return repository.SelectFromSp<WorkCalendarViewModel>("spGetWorkCalendarFor", new
        {
            searchModel.SalonGuid,
            searchModel.YearId,
            searchModel.MonthId
        });
    }
}
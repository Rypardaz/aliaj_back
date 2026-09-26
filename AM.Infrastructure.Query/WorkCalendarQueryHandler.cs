using PhoenixFramework.Dapper;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;

namespace Lab.Infrastructure.Query;

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
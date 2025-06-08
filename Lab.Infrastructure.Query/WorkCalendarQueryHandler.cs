using PhoenixFramework.Dapper;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;

namespace Lab.Infrastructure.Query
{
    public class WorkCalendarQueryHandler : IQueryHandler<List<WorkCalendarViewModel>, WorkCalendarSearchModel>
    {
        private readonly BaseDapperRepository _repository;

        public WorkCalendarQueryHandler(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<WorkCalendarViewModel> Handle(WorkCalendarSearchModel searchModel)
        {
            return _repository.SelectFromSp<WorkCalendarViewModel>("spGetWorkCalendarFor", new
            {
                searchModel.SalonGuid,
                searchModel.YearId,
                searchModel.MonthId
            });
        }
    }
}
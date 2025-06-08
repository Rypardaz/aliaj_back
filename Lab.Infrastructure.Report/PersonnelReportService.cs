using Lab.Infrastructure.Report.Contract.PersonnelReport;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report;

public class PersonnelReportService : IPersonnelReportService
{
    private readonly BaseDapperRepository _repository;

    public PersonnelReportService(BaseDapperRepository repository)
    {
        _repository = repository;
    }

    public List<PersonnelReportViewModel> GetPersonnelReport(PersonnelReportSearchModel searchModel)
    {
        string? weekIds = null;
        if (searchModel.WeekIds is not null)
            weekIds = string.Join(",", searchModel.WeekIds);

        string? monthIds = null;
        if (searchModel.MonthIds is not null)
            monthIds = string.Join(",", searchModel.MonthIds);

        string? yearIds = null;
        if (searchModel.YearIds is not null)
            yearIds = string.Join(",", searchModel.YearIds);

        return _repository.SelectFromSp<PersonnelReportViewModel>("spPersonnelReport", new
        {
            searchModel.SalonGuid,
            searchModel.PersonnelGuid,
            WeekIds = weekIds,
            MonthIds = monthIds,
            YearIds = yearIds,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}
using Lab.Infrastructure.Report.Contract.PersonnelReport;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Report
{
    public class PersonnelReportService : IPersonnelReportService
    {
        private readonly BaseDapperRepository _repository;

        public PersonnelReportService(BaseDapperRepository repository)
        {
            _repository = repository;
        }

        public List<PersonnelReportViewModel> GetPersonnelReport(PersonnelReportSearchModel searchModel) =>
            _repository.SelectFromSp<PersonnelReportViewModel>("spPersonnelReport", new
            {
                searchModel.PersonnelGuid,
                searchModel.WeekId,
                searchModel.MonthId,
                searchModel.FromDate,
                searchModel.ToDate
            });
    }

}
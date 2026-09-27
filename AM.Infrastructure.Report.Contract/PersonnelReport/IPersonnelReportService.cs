using PhoenixFramework.Core;

namespace AM.Infrastructure.Report.Contract.PersonnelReport;

public interface IPersonnelReportService : IReportService
{
    List<PersonnelReportViewModel> GetPersonnelReport(PersonnelReportSearchModel searchModel);
}
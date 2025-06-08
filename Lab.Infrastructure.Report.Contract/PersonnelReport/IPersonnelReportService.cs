using PhoenixFramework.Core;

namespace Lab.Infrastructure.Report.Contract.PersonnelReport;

public interface IPersonnelReportService : IReportService
{
    List<PersonnelReportViewModel> GetPersonnelReport(PersonnelReportSearchModel searchModel);
}
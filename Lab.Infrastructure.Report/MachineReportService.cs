using PhoenixFramework.Dapper;
using Lab.Infrastructure.Report.Contract;
using Lab.Infrastructure.Report.Contract.MachineReport;

namespace Lab.Infrastructure.Report;

public class MachineReportService : IMachineReportService
{
    private readonly BaseDapperRepository _dapper;

    public MachineReportService(BaseDapperRepository dapper)
    {
        _dapper = dapper;
    }

    public List<ActivityNameViewModel> GetActivityNames(Guid salonGuid)
    {
        return _dapper.SelectFromSp<ActivityNameViewModel>("spMachineReport", new
        {
            Type = 0,
            SalonGuid = salonGuid
        });
    }

    public List<MachineReportModel> GetMachineReport(MachineReportSearchModel searchModel)
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
        
        return _dapper.SelectFromSp<MachineReportModel>("spMachineReport", new
        {
            searchModel.Type,
            searchModel.SalonGuid,
            searchModel.ShiftGuid,
            WeekIds = weekIds,
            MonthIds = monthIds,
            YearIds = yearIds,
            searchModel.FromDate,
            searchModel.ToDate
        });
    }
}
using Microsoft.AspNetCore.Mvc;
using Lab.Infrastructure.Report.Contract.ByPart;
using Lab.Infrastructure.Report.Contract.Activity;
using Lab.Infrastructure.Report.Contract.Dashboard;
using Lab.Infrastructure.Report.Contract.DataLogger;
using Lab.Infrastructure.Report.Contract.Management;
using Lab.Infrastructure.Report.Contract.MachineReport;
using Lab.Infrastructure.Report.Contract.ProjectReport;
using Lab.Infrastructure.Report.Contract.PersonnelReport;
using Lab.Infrastructure.Report.Contract.WeldingTime;
using Lab.Infrastructure.Report.Contract.WireTypeConsumption;
using Lab.Infrastructure.Report.Contract.FinalCardProject;
using Lab.Infrastructure.Report.Contract.DailyRecordListReport;
using Lab.Infrastructure.Report.Contract.BachReportOnDate;
using Lab.Infrastructure.Report.Contract.DailyRecordListProductUnitsReport;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class ReportController(
    IManagementReportService managementReportService,
    IWireTypeConsumptionReportService wireTypeConsumptionReportService,
    IActivityReportService activityReportService,
    IByPartReportService byPartReportService,
    IProjectReportService projectReportService,
    IPersonnelReportService personnelReportService,
    IDataLoggerReportService dataLoggerReportService,
    IMachineReportService machineReportService,
    IWeldingTimeReportService weldingTimeReportService,
    IDashboardReportService dashboardReportService,
    IFinalCardProjectReportService fInalCardProjectService,
    IDailyRecordListReportService dailyRecordListReportService,
    IBachReportOnDateReportService bachReportOnDateReportService,
    IDailyRecordListProductUnitsReportService dailyRecordListProductUnitsReportService)
    : ControllerBase
{
    [HttpGet("GetActivityNames/{salonGuid:guid}")]
    public IActionResult GetActivityNames(Guid salonGuid) =>
        new JsonResult(managementReportService.GetActivityNames(salonGuid));

    [HttpPut("GetDailyRecordReport")]
    public IActionResult GetDailyRecordReport([FromBody] DailyRecordSearchModel searchModel) =>
        new JsonResult(managementReportService.GetMachineDailyRecordReport(searchModel));

    [HttpPut("GetWireTypeConsumptionReport")]
    public IActionResult
        GetWireTypeConsumptionReport([FromBody] WireTypeConsumptionReportSearchModel searchModel) =>
        new JsonResult(wireTypeConsumptionReportService.GetWireTypeConsumptionReport(searchModel));

    [HttpGet("GetActivityNamesForActivityReport/{salonGuid:guid}")]
    public IActionResult GetActivityNamesForActivityReport(Guid salonGuid) =>
        new JsonResult(activityReportService.GetActivityNames(salonGuid));

    [HttpPut("GetActivityReport")]
    public IActionResult GetActivityReport([FromBody] ActivityReportSearchModel searchModel) =>
        new JsonResult(activityReportService.GetActivityReport(searchModel));

    [HttpGet("GetByPartReport")]
    public IActionResult GetByPartReport([FromQuery] ByPartReportSearchModel searchModel) =>
        new JsonResult(byPartReportService.GetByPartReport(searchModel));

    [HttpPut("GetProjectWireTypes")]
    public IActionResult GetProjectWireTypes([FromBody] ProjectReportSearchModel searchModel) =>
        new JsonResult(projectReportService.GetProjectWireTypes(searchModel));

    [HttpPut("GetProjectReport")]
    public IActionResult GetProjectReport([FromBody] ProjectReportSearchModel searchModel) =>
        new JsonResult(projectReportService.GetProjectReport(searchModel));

    [HttpPut("GetPersonnelReport")]
    public IActionResult GetPersonnelReport([FromBody] PersonnelReportSearchModel searchModel) =>
        new JsonResult(personnelReportService.GetPersonnelReport(searchModel));

    [HttpGet("GetActivityNamesForMachineReport/{salonGuid:guid}")]
    public IActionResult GetActivityNamesForMachineReport(Guid salonGuid) =>
        new JsonResult(machineReportService.GetActivityNames(salonGuid));

    [HttpPut("GetMachineReport")]
    public IActionResult GetMachineReport([FromBody] MachineReportSearchModel searchModel) =>
        new JsonResult(machineReportService.GetMachineReport(searchModel));

    [HttpPut("GetWeldingTimeReport")]
    public IActionResult GetWeldingTimeReport([FromBody] WeldingTimeSearchModel searchModel) =>
        new JsonResult(weldingTimeReportService.GetReport(searchModel));

    [HttpPut("GetDataLoggerReport")]
    public IActionResult GetDataLoggerReport([FromBody] DataLoggerReportSearchModel searchModel) =>
        new JsonResult(dataLoggerReportService.GetDataLoggerReport(searchModel));

    [HttpPut("DashboardReport")]
    public IActionResult DashboardReport([FromBody] DashboardSearchModel searchModel) =>
        new JsonResult(dashboardReportService.GetReport(searchModel));

    [HttpPut("GetFinalCardProject")]
    public IActionResult GetFinalCardProject([FromBody] FinalCardProjectReportSearchModel searchModel) =>
        new JsonResult(fInalCardProjectService.GetFinalCardProject(searchModel));

    [HttpPut("GetDailyRecordListReport")]
    public IActionResult GetDailyRecordListReport([FromBody] DailyRecordListReportSearchModel searchModel) =>
        new JsonResult(dailyRecordListReportService.GetDailyRecordListReport(searchModel));

    [HttpPut("GetBachReportOnDate")]
    public IActionResult GetBachReportOnDate([FromBody] BachReportOnDateReportSearchModel searchModel) =>
        new JsonResult(bachReportOnDateReportService.GetBachReportOnDate(searchModel));

    [HttpPut("GetDailyRecordListProductUnitsReport")]
    public IActionResult GetDailyRecordListProductUnitsReport([FromBody] DailyRecordListProductUnitsReportSearchModel searchModel) =>
        new JsonResult(dailyRecordListProductUnitsReportService.GetDailyRecordListProductUnitsReport(searchModel));

}
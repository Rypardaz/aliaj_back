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
public class ReportController : ControllerBase
{
    private readonly IManagementReportService _managementReportService;
    private readonly IWireTypeConsumptionReportService _wireTypeConsumptionReportService;
    private readonly IActivityReportService _activityReportService;
    private readonly IByPartReportService _byPartReportService;
    private readonly IProjectReportService _projectReportService;
    private readonly IPersonnelReportService _personnelReportService;
    private readonly IDataLoggerReportService _dataLoggerReportService;
    private readonly IMachineReportService _machineReportService;
    private readonly IWeldingTimeReportService _weldingTimeReportService;
    private readonly IDashboardReportService _dashboardReportService;
    private readonly IFinalCardProjectReportService _fInalCardProjectService;
    private readonly IDailyRecordListReportService _dailyRecordListReportService;
    private readonly IBachReportOnDateReportService _bachReportOnDateReportService;
    private readonly IDailyRecordListProductUnitsReportService _dailyRecordListProductUnitsReportService;

    public ReportController(
        IManagementReportService managementReportService,
        IWireTypeConsumptionReportService wireTypeConsumptionReportService,
        IActivityReportService activityReportService,
        IByPartReportService byPartReportService,
        IProjectReportService projectReportService,
        IPersonnelReportService personnelReportService, IDataLoggerReportService dataLoggerReportService,
        IMachineReportService machineReportService, IWeldingTimeReportService weldingTimeReportService,
        IDashboardReportService dashboardReportService,
        IFinalCardProjectReportService fInalCardProjectService,
        IDailyRecordListReportService dailyRecordListReportService,
        IBachReportOnDateReportService bachReportOnDateReportService,
        IDailyRecordListProductUnitsReportService dailyRecordListProductUnitsReportService
        )
    {
        _managementReportService = managementReportService;
        _wireTypeConsumptionReportService = wireTypeConsumptionReportService;
        _activityReportService = activityReportService;
        _byPartReportService = byPartReportService;
        _projectReportService = projectReportService;
        _personnelReportService = personnelReportService;
        _dataLoggerReportService = dataLoggerReportService;
        _machineReportService = machineReportService;
        _weldingTimeReportService = weldingTimeReportService;
        _dashboardReportService = dashboardReportService;
        _fInalCardProjectService = fInalCardProjectService;
        _dailyRecordListReportService = dailyRecordListReportService;
        _bachReportOnDateReportService = bachReportOnDateReportService;
        _dailyRecordListProductUnitsReportService = dailyRecordListProductUnitsReportService;
    }

    [HttpGet("GetActivityNames/{salonGuid:guid}")]
    public IActionResult GetActivityNames(Guid salonGuid) =>
        new JsonResult(_managementReportService.GetActivityNames(salonGuid));

    [HttpPut("GetDailyRecordReport")]
    public IActionResult GetDailyRecordReport([FromBody] DailyRecordSearchModel searchModel) =>
        new JsonResult(_managementReportService.GetMachineDailyRecordReport(searchModel));

    [HttpPut("GetWireTypeConsumptionReport")]
    public IActionResult
        GetWireTypeConsumptionReport([FromBody] WireTypeConsumptionReportSearchModel searchModel) =>
        new JsonResult(_wireTypeConsumptionReportService.GetWireTypeConsumptionReport(searchModel));

    [HttpGet("GetActivityNamesForActivityReport/{salonGuid:guid}")]
    public IActionResult GetActivityNamesForActivityReport(Guid salonGuid) =>
        new JsonResult(_activityReportService.GetActivityNames(salonGuid));

    [HttpPut("GetActivityReport")]
    public IActionResult GetActivityReport([FromBody] ActivityReportSearchModel searchModel) =>
        new JsonResult(_activityReportService.GetActivityReport(searchModel));

    [HttpGet("GetByPartReport")]
    public IActionResult GetByPartReport([FromQuery] ByPartReportSearchModel searchModel) =>
        new JsonResult(_byPartReportService.GetByPartReport(searchModel));

    [HttpPut("GetProjectWireTypes")]
    public IActionResult GetProjectWireTypes([FromBody] ProjectReportSearchModel searchModel) =>
        new JsonResult(_projectReportService.GetProjectWireTypes(searchModel));

    [HttpPut("GetProjectReport")]
    public IActionResult GetProjectReport([FromBody] ProjectReportSearchModel searchModel) =>
        new JsonResult(_projectReportService.GetProjectReport(searchModel));

    [HttpPut("GetPersonnelReport")]
    public IActionResult GetPersonnelReport([FromBody] PersonnelReportSearchModel searchModel) =>
        new JsonResult(_personnelReportService.GetPersonnelReport(searchModel));

    [HttpGet("GetActivityNamesForMachineReport/{salonGuid:guid}")]
    public IActionResult GetActivityNamesForMachineReport(Guid salonGuid) =>
        new JsonResult(_machineReportService.GetActivityNames(salonGuid));

    [HttpPut("GetMachineReport")]
    public IActionResult GetMachineReport([FromBody] MachineReportSearchModel searchModel) =>
        new JsonResult(_machineReportService.GetMachineReport(searchModel));

    [HttpPut("GetWeldingTimeReport")]
    public IActionResult GetWeldingTimeReport([FromBody] WeldingTimeSearchModel searchModel) =>
        new JsonResult(_weldingTimeReportService.GetReport(searchModel));

    [HttpPut("GetDataLoggerReport")]
    public IActionResult GetDataLoggerReport([FromBody] DataLoggerReportSearchModel searchModel) =>
        new JsonResult(_dataLoggerReportService.GetDataLoggerReport(searchModel));

    [HttpPut("DashboardReport")]
    public IActionResult DashboardReport([FromBody] DashboardSearchModel searchModel) =>
        new JsonResult(_dashboardReportService.GetReport(searchModel));

    [HttpPut("GetFinalCardProject")]
    public IActionResult GetFinalCardProject([FromBody] FinalCardProjectReportSearchModel searchModel) =>
        new JsonResult(_fInalCardProjectService.GetFinalCardProject(searchModel));

    [HttpPut("GetDailyRecordListReport")]
    public IActionResult GetDailyRecordListReport([FromBody] DailyRecordListReportSearchModel searchModel) =>
        new JsonResult(_dailyRecordListReportService.GetDailyRecordListReport(searchModel));

    [HttpPut("GetBachReportOnDate")]
    public IActionResult GetBachReportOnDate([FromBody] BachReportOnDateReportSearchModel searchModel) =>
        new JsonResult(_bachReportOnDateReportService.GetBachReportOnDate(searchModel));

    [HttpPut("GetDailyRecordListProductUnitsReport")]
    public IActionResult GetDailyRecordListProductUnitsReport([FromBody] DailyRecordListProductUnitsReportSearchModel searchModel) =>
        new JsonResult(_dailyRecordListProductUnitsReportService.GetDailyRecordListProductUnitsReport(searchModel));

}
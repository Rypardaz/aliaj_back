using Microsoft.AspNetCore.Mvc;
using Lab.Infrastructure.Report.Contract.WireTypeConsumption;
using Lab.Infrastructure.Report.Contract.Activity;
using Lab.Infrastructure.Report.Contract.ByPart;
using Lab.Infrastructure.Report.Contract.Management;
using Lab.Infrastructure.Report.Contract.ProjectReport;
using Lab.Infrastructure.Report.Contract.PersonnelReport;

namespace Lab.Presentation.Api
{
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

        public ReportController(
            IManagementReportService managementReportService, 
            IWireTypeConsumptionReportService wireTypeConsumptionReportService,
            IActivityReportService activityReportService,
            IByPartReportService byPartReportService,
            IProjectReportService projectReportService,
            IPersonnelReportService personnelReportService)
        {
            _managementReportService = managementReportService;
            _wireTypeConsumptionReportService = wireTypeConsumptionReportService;
            _activityReportService = activityReportService;
            _byPartReportService = byPartReportService;
            _projectReportService = projectReportService;
            _personnelReportService = personnelReportService;
        }

        [HttpGet("GetActivityNames/{salonGuid:guid}")]
        public IActionResult GetActivityNames(Guid salonGuid) => new JsonResult(_managementReportService.GetActivityNames(salonGuid));

        [HttpGet("GetMachineDailyRecordReport")]
        public IActionResult GetMachineDailyRecordReport([FromQuery] MachineDailyRecordSearchModel searchModel) =>
            new JsonResult(_managementReportService.GetMachineDailyRecordReport(searchModel));


        [HttpGet("GetWireTypeConsumptionReport")]
        public IActionResult GetWireTypeConsumptionReport([FromQuery] WireTypeConsumptionReportSearchModel searchModel) =>
            new JsonResult(_wireTypeConsumptionReportService.GetWireTypeConsumptionReport(searchModel));


        [HttpGet("GetActivityReport")]
        public IActionResult GetActivityReport([FromQuery] ActivityReportSearchModel searchModel) =>
            new JsonResult(_activityReportService.GetActivityReport(searchModel));


        [HttpGet("GetByPartReport")]
        public IActionResult GetByPartReport([FromQuery] ByPartReportSearchModel searchModel) =>
            new JsonResult(_byPartReportService.GetByPartReport(searchModel));


        [HttpGet("GetProjectReport")]
        public IActionResult GetProjectReport([FromQuery] ProjectReportSearchModel searchModel) =>
            new JsonResult(_projectReportService.GetProjectReport(searchModel));


        [HttpGet("GetPersonnelReport")]
        public IActionResult GetPersonnelReport([FromQuery] PersonnelReportSearchModel searchModel) =>
            new JsonResult(_personnelReportService.GetPersonnelReport(searchModel));
    }
}
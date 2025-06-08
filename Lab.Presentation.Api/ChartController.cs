using Microsoft.AspNetCore.Mvc;
using Lab.Infrastructure.Report.Contract.Chart;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class ChartController : ControllerBase
{
    private readonly IChartReportService _chartReportService;

    public ChartController(IChartReportService chartReportService)
    {
        _chartReportService = chartReportService;
    }

    [HttpPut("GetWireConsumptionChart")]
    public IActionResult GetWireConsumptionChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(_chartReportService.GetWireConsumptionChart(searchModel));

    [HttpPut("GetRandemanChart")]
    public IActionResult GetRandemanChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(_chartReportService.GetRandemanChart(searchModel));

    [HttpPut("GetWireConsumptionToStandardChart")]
    public IActionResult GetWireConsumptionToStandardChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(_chartReportService.GetWireConsumptionToStandardChart(searchModel));

    [HttpPut("GetActivityChart")]
    public IActionResult GetActivityChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(_chartReportService.GetActivityChart(searchModel));

    [HttpPut("GetProjectChart")]
    public IActionResult GetProjectChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(_chartReportService.GetProjectChart(searchModel));
}
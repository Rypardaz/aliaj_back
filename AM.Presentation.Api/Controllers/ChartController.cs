using Microsoft.AspNetCore.Mvc;
using Lab.Infrastructure.Report.Contract.Chart;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class ChartController(IChartReportService chartReportService) : ControllerBase
{
    [HttpPut("GetWireConsumptionChart")]
    public IActionResult GetWireConsumptionChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(chartReportService.GetWireConsumptionChart(searchModel));

    [HttpPut("GetRandemanChart")]
    public IActionResult GetRandemanChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(chartReportService.GetRandemanChart(searchModel));

    [HttpPut("GetWireConsumptionToStandardChart")]
    public IActionResult GetWireConsumptionToStandardChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(chartReportService.GetWireConsumptionToStandardChart(searchModel));

    [HttpPut("GetActivityChart")]
    public IActionResult GetActivityChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(chartReportService.GetActivityChart(searchModel));

    [HttpPut("GetProjectChart")]
    public IActionResult GetProjectChart([FromBody] ChartSearchModel searchModel)
        => new JsonResult(chartReportService.GetProjectChart(searchModel));
}
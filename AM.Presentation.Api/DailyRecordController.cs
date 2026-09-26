using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.Project;
using Lab.Infrastructure.Query.Contracts.DailyRecord;
using Lab.Presentation.Facade.Contract.DailyRecord;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class DailyRecordController(IDailyRecordCommandFacade commandFacade, IDailyRecordQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateDailyRecord command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditDailyRecord command) => commandFacade.Edit(command);

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) => commandFacade.Remove(guid);

    [HttpGet("GetList")]
    public IActionResult List([FromQuery] DailyRecordSearchModel searchModel) => 
        new JsonResult(queryFacade.List(searchModel));

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid) => new JsonResult(queryFacade.GetDetails(guid));

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo() => new JsonResult(queryFacade.Combo());
}
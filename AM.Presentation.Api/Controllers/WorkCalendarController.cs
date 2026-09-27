using Microsoft.AspNetCore.Mvc;
using Lab.Presentation.Facade.Contract.WorkCalendar;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;
using Ex.Application.Contracts.WorkCalendar;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class WorkCalendarController(IWorkCalendarQueryFacade queryFacade, IWorkCalendarCommandFacade commandFacade)
    : ControllerBase
{
    [HttpPost("Edit")]
    public void Edit([FromBody] EditWorkCalendar command) =>
        commandFacade.Edit(command);

    [HttpGet("GetList")]
    public IActionResult List([FromQuery] WorkCalendarSearchModel searchModel)
        => new JsonResult(queryFacade.GetList(searchModel));
}
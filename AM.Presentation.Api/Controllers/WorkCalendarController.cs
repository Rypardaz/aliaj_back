using AM.Application.Contracts.WorkCalendar;
using AM.Infrastructure.Query.Contract.WorkCalendar;
using AM.Presentation.Facade.Contract.WorkCalendar;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

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
using Microsoft.AspNetCore.Mvc;
using Lab.Presentation.Facade.Contract.WorkCalendar;
using Lab.Infrastructure.Query.Contracts.WorkCalendar;
using Ex.Application.Contracts.WorkCalendar;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkCalendarController : ControllerBase
    {
        private readonly IWorkCalendarQueryFacade _queryFacade;
        private readonly IWorkCalendarCommandFacade _commandFacade;

        public WorkCalendarController(IWorkCalendarQueryFacade queryFacade, IWorkCalendarCommandFacade commandFacade)
        {
            _queryFacade = queryFacade;
            _commandFacade = commandFacade;
        }

        [HttpPost("Edit")]
        public void Edit([FromBody] EditWorkCalendar command) =>
            _commandFacade.Edit(command);

        [HttpGet("GetList")]
        public IActionResult List([FromQuery] WorkCalendarSearchModel searchModel)
            => new JsonResult(_queryFacade.GetList(searchModel));
    }
}

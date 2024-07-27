using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.DailyRecord;
using Lab.Infrastructure.Query.Contracts.Project;
using Lab.Infrastructure.Query.Contracts.DailyRecord;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class DailyRecordController : ControllerBase
    {

        private readonly IDailyRecordQueryFacade _queryFacade;
        private readonly IDailyRecordCommandFacade _commandFacade;

        public DailyRecordController(IDailyRecordCommandFacade commandFacade, IDailyRecordQueryFacade queryFacade)
        {
            _queryFacade = queryFacade;
            _commandFacade = commandFacade;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateDailyRecord command) =>
            new JsonResult(_commandFacade.Create(command));

        [HttpPost("Edit")]
        public void Edit([FromBody] EditDailyRecord command) => _commandFacade.Edit(command);

        [HttpPost("Delete/{guid:guid}")]
        public void Delete(Guid guid) => _commandFacade.Remove(guid);

        [HttpGet("GetList")]
        public IActionResult List([FromQuery] DailyRecordSearchModel searchModel) => 
            new JsonResult(_queryFacade.List(searchModel));

        [HttpGet("GetForEdit/{guid:guid}")]
        public IActionResult GetDetails(Guid guid) => new JsonResult(_queryFacade.GetDetails(guid));

        [HttpGet("GetForCombo")]
        public IActionResult GetForCombo() => new JsonResult(_queryFacade.Combo());
    }
}

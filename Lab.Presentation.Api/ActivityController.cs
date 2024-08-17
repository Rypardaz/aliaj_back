using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.Activity;
using Lab.Presentation.Facade.Contract.Activity;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityCommandFacade _commandFacade;
        private readonly IActivityQueryFacade _queryFacade;

        public ActivityController(IActivityCommandFacade commandFacade, IActivityQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateActivity command) =>
            new JsonResult(_commandFacade.Create(command));

        [HttpPost("Edit")]
        public void Edit([FromBody] EditActivity command) =>
            _commandFacade.Edit(command);

        [HttpPost("Delete/{guid:guid}")]
        public void Delete(Guid guid) =>
           _commandFacade.Delete(guid);

        [HttpPost("Activate/{guid:guid}")]
        public void Activate(Guid guid) =>
        _commandFacade.Activate(guid);

        [HttpPost("DeActivate/{guid:guid}")]
        public void DeActivate(Guid guid) =>
          _commandFacade.Deactivate(guid);

        [HttpGet("GetList")]
        public IActionResult List()
            => new JsonResult(_queryFacade.List());

        [HttpGet("GetForEdit/{guid:guid}")]
        public IActionResult GetDetails(Guid guid)
            => new JsonResult(_queryFacade.GetDetails(guid));

        [HttpGet("GetForCombo/{salonGuid?}")]
        public IActionResult GetForCombo(Guid? salonGuid)
            => new JsonResult(_queryFacade.Combo(salonGuid));
    }
}
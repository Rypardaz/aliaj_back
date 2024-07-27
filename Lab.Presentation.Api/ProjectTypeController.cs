using Ex.Application.Contracts.ProjectType;
using Lab.Presentation.Facade.Contract.ProjectType;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectTypeController : ControllerBase
    {

        private readonly IProjectTypeCommandFacade _commandFacade;
        private readonly IProjectTypeQueryFacade _queryFacade;

        public ProjectTypeController(IProjectTypeCommandFacade commandFacade, IProjectTypeQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProjectType command) =>
            new JsonResult(await _commandFacade.Create(command));

        [HttpPost("Edit")]
        public async Task Edit([FromBody] EditProjectType command) =>
            await _commandFacade.Edit(command);

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

        [HttpGet("GetForCombo/{salonGuid:guid}")]
        public IActionResult GetForCombo(Guid salonGuid)
            => new JsonResult(_queryFacade.Combo(salonGuid));
    }
}
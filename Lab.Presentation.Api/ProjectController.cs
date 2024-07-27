using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.Project;
using Lab.Presentation.Facade.Contract.Project;
using Lab.Infrastructure.Query.Contracts.Project;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectQueryFacade _queryFacade;
        private readonly IProjectCommandFacade _commandFacade;

        public ProjectController(IProjectCommandFacade commandFacade, IProjectQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateProject command) =>
            new JsonResult(_commandFacade.Create(command));

        [HttpPost("Edit")]
        public void Edit([FromBody] EditProject command) =>
            _commandFacade.Edit(command);

        [HttpPost("Delete/{guid:guid}")]
        public void Delete(Guid guid) =>
           _commandFacade.Delete(guid);

        [HttpGet("GetList")]
        public IActionResult List([FromQuery] ProjectSearchModel searchModel)
            => new JsonResult(_queryFacade.List(searchModel));

        [HttpGet("GetForEdit/{guid:guid}")]
        public IActionResult GetDetails(Guid guid)
            => new JsonResult(_queryFacade.GetDetails(guid));

        [HttpGet("GetForCombo")]
        public IActionResult GetForCombo()
            => new JsonResult(_queryFacade.Combo());

        [HttpGet("DetailsCombo/{salonGuid:guid}")]
        public IActionResult DetailsCombo(Guid salonGuid)
            => new JsonResult(_queryFacade.DetailsCombo(salonGuid));
    }
}

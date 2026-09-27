using AM.Application.Contracts.Project;
using AM.Infrastructure.Query.Contract.Project;
using AM.Presentation.Facade.Contract.Project;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(IProjectCommandFacade commandFacade, IProjectQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProject command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditProject command) =>
        commandFacade.Edit(command);

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) =>
        commandFacade.Delete(guid);

    [HttpGet("GetList")]
    public IActionResult List([FromQuery] ProjectSearchModel searchModel)
        => new JsonResult(queryFacade.List(searchModel));

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid)
        => new JsonResult(queryFacade.GetDetails(guid));

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo([FromQuery] ProjectSearchModel searchModel)
        => new JsonResult(queryFacade.Combo(searchModel));

    [HttpGet("DetailsCombo/{projectGuid:guid}")]
    public IActionResult DetailsCombo(Guid projectGuid)
        => new JsonResult(queryFacade.DetailsCombo(projectGuid));

    [HttpGet("GetReplacements/{projectGuid:guid}")]
    public IActionResult GetReplacements(Guid projectGuid)
        => new JsonResult(queryFacade.GetReplacements(projectGuid));

    [HttpGet("GetProjectStep")]
    public IActionResult GetProjectStep([FromQuery] ProjectStepSearchModel searchModel)
        => new JsonResult(queryFacade.GetProjectStep(searchModel));
}
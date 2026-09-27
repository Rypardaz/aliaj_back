using AM.Application.Contracts.ProjectType;
using AM.Presentation.Facade.Contract.ProjectType;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectTypeController(IProjectTypeCommandFacade commandFacade, IProjectTypeQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateProjectType command) =>
        new JsonResult(await commandFacade.Create(command));

    [HttpPost("Edit")]
    public async Task Edit([FromBody] EditProjectType command) =>
        await commandFacade.Edit(command);

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) =>
        commandFacade.Delete(guid);

    [HttpPost("Activate/{guid:guid}")]
    public void Activate(Guid guid) =>
        commandFacade.Activate(guid);

    [HttpPost("DeActivate/{guid:guid}")]
    public void DeActivate(Guid guid) =>
        commandFacade.Deactivate(guid);

    [HttpGet("GetList")]
    public IActionResult List()
        => new JsonResult(queryFacade.List());

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid)
        => new JsonResult(queryFacade.GetDetails(guid));

    [HttpGet("GetForCombo/{salonGuid:guid}")]
    public IActionResult GetForCombo(Guid salonGuid)
        => new JsonResult(queryFacade.Combo(salonGuid));
}
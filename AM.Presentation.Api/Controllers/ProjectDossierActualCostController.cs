using AM.Application.Contracts.ProjectDossierActualCost;
using AM.Presentation.Facade.Contract.ProjectDossierActualCost;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectDossierActualCostController(IProjectDossierActualCostCommandFacade commandFacade, IProjectDossierActualCostQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProjectDossierActualCost command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditProjectDossierActualCost command) =>
        commandFacade.Edit(command);

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) =>
        commandFacade.Delete(guid);

    [HttpGet("GetList")]
    public IActionResult List()
        => new JsonResult(queryFacade.List());

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid)
        => new JsonResult(queryFacade.GetDetails(guid));

}

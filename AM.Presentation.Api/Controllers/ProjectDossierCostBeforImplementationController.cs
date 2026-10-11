using AM.Application.Contracts.ProjectDossierCostBeforImplementation;
using AM.Presentation.Facade.Contract.ProjectDossierCostBeforImplementation;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectDossierCostBeforImplementationController(IProjectDossierCostBeforImplementationCommandFacade commandFacade, IProjectDossierCostBeforImplementationQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProjectDossierCostBeforImplementation command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditProjectDossierCostBeforImplementation command) =>
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

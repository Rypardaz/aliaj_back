using AM.Application.Contracts.ProjectDossierProduct;
using AM.Presentation.Facade.Contract.ProjectDossierProduct;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectDossierProductController(IProjectDossierProductCommandFacade commandFacade, IProjectDossierProductQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProjectDossierProduct command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditProjectDossierProduct command) =>
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

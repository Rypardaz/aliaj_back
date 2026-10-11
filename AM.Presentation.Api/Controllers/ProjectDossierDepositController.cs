using AM.Application.Contracts.ProjectDossierDeposit;
using AM.Presentation.Facade.Contract.ProjectDossierDeposit;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectDossierDepositController(IProjectDossierDepositCommandFacade commandFacade, IProjectDossierDepositQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProjectDossierDeposit command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditProjectDossierDeposit command) =>
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

using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.Activity;
using Lab.Presentation.Facade.Contract.Activity;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class ActivityController(IActivityCommandFacade commandFacade, IActivityQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateActivity command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditActivity command) =>
        commandFacade.Edit(command);

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

    [HttpGet("GetForCombo/{salonGuid?}")]
    public IActionResult GetForCombo(Guid? salonGuid)
        => new JsonResult(queryFacade.Combo(salonGuid));
}
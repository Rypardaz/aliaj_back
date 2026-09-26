using Ex.Application.Contracts.GasTypeGroup;
using Lab.Presentation.Facade.Contract.GasTypeGroup;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class GasTypeGroupController(IGasTypeGroupCommandFacade commandFacade, IGasTypeGroupQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateGasTypeGroup command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditGasTypeGroup command) =>
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

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo()
        => new JsonResult(queryFacade.Combo());
}
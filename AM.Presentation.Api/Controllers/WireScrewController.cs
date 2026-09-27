using AM.Application.Contracts.WireScrew;
using AM.Infrastructure.Query.Contract.WireScrew;
using AM.Presentation.Facade.Contract.WireScrew;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WireScrewController(IWireScrewCommandFacade commandFacade, IWireScrewQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateWireScrew command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditWireScrew command) =>
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

    [HttpPut("GetProductionWireScrews")]
    public IActionResult GetProductionWireScrews([FromBody] ProductionWireScrewSearchModel searchModel)
        => new JsonResult(queryFacade.GetProductionWireScrews(searchModel));
}
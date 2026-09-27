using Ex.Application.Contracts.Personnel;
using Lab.Infrastructure.Query.Contracts.Personnel;
using Lab.Presentation.Facade.Contract.Personnel;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class PersonnelController(IPersonnelCommandFacade commandFacade, IPersonnelQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreatePersonnel command) =>
        new JsonResult(await commandFacade.Create(command));

    [HttpPost("Edit")]
    public async Task Edit([FromBody] EditPersonnel command) =>
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

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo([FromQuery] PersonnelSearchModel searchModel)
        => new JsonResult(queryFacade.Combo(searchModel));
}
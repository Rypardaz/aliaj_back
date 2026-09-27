using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.Role;
using Lab.Presentation.Facade.Contract.Role;

namespace Lab.Presentation.Api;

[Route("api/[controller]")]
[ApiController]
public class RoleController(IRoleCommandFacade commandFacade, IRoleQueryFacade queryFacade) : ControllerBase
{
    [HttpPost("Create")]
    public void Post(CreateRole command) => commandFacade.Create(command);

    [HttpPost("Edit")]
    public void Edit(EditRole command) => commandFacade.Edit(command);

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) => commandFacade.Delete(guid);

    [HttpGet("GetList")]
    public IActionResult List() => new JsonResult(queryFacade.GetList());

    [HttpGet("GetBy/{guid:guid}")]
    public IActionResult GetBy(Guid guid) => new JsonResult(queryFacade.GetForEdit(guid));

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo() => new JsonResult(queryFacade.GetForCombo());
}
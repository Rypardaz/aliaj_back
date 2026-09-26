using Ex.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Presentation.Api;

[Route("api/[controller]")]
[ApiController]
public class UserGroupController(IRoleApplication roleApplication) : ControllerBase
{
    [HttpPost("Create")]
    public void Post(CreateRole command)
    {
        roleApplication.Create(command);
    }

    [HttpGet("GetList")]
    public List<RoleViewModel> List()
    {
        return roleApplication.List();
    }

    [HttpGet("GetBy/{guid:guid}")]
    public EditRole GetBy(Guid guid)
    {
        return roleApplication.GetDetails(guid);
    }
    //
    // [HttpGet("GetForCombo")]
    // public IActionResult GetForCombo()
    // {
    //     return new JsonResult(roleApplication.GetForCombo());
    // }

    [HttpPost("Edit")]
    public void Edit(EditRole command)
    {
        roleApplication.Edit(command);
    }

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid)
    {
        roleApplication.Delete(guid);
    }
}
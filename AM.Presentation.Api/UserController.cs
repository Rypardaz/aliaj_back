using Ex.Application.Contracts.User;
using Lab.Infrastructure.Query.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class UserController(IQueryBus queryBus, IQueryBusAsync queryBusAsync, IUserApplication userApplication)
    : ControllerBase
{
    [HttpPost("Create")]
    public void Post([FromBody] CreateUser command)
    {
        userApplication.Create(command);
    }

    [HttpPost("Deactivate/{guid:guid}")]
    public void Lock(Guid guid)
    {
        userApplication.Lock(guid);
    }

    [HttpPost("Activate/{guid:guid}")]
    public void Unlock(Guid guid)
    {
        userApplication.Unlock(guid);
    }

    [HttpGet("GetList")]
    public List<UserViewModel> Search()
    {
        var a = userApplication.GetList();
        return a;
    }

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid)
    {
        userApplication.Delete(guid);
    }

    [HttpPost("OpenSession")]
    public void OpenSession([FromBody] OpenSession command)
    {
        command.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        userApplication.OpenSession(command);
    }

    [HttpGet("GetBy/{guid:guid}")]
    public EditUser GetBy(Guid guid)
    {
        return userApplication.GetBy(guid);
    }

    [HttpPost("Edit")]
    public void Put([FromBody] EditUser command)
    {
        userApplication.Edit(command);
    }

    [HttpPost("ChangePassword")]
    public void ChangePassword(ChangePassword command)
    {
        userApplication.ChangePassword(command);
    }

    [AllowAnonymous]
    [HttpPost("CloseSessions/{guid:guid}")]
    public void CloseSessions(Guid guid)
    {
        userApplication.CloseSession(guid);
    }

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo()
    {
        return new JsonResult(queryBus.Dispatch<List<UserComboModel>>());
    }

    [HttpGet("GetUserInformation")]
    public async Task<IActionResult> GetUserInformation()
    {
        return new JsonResult(await queryBusAsync.Dispatch<UserInformationViewModel>());
    }

    [HttpGet("GetCurrentUserLastSessions")]
    public async Task<IActionResult> GetCurrentUserLastSessions()
    {
        return new JsonResult(await queryBusAsync.Dispatch<List<UserSessionViewModel>>());
    }

    [HttpGet("HasActiveSession")]
    public async Task<IActionResult> HasActiveSession()
    {
        var claims = HttpContext.User.Claims.ToList();
        return new JsonResult(await queryBusAsync.Dispatch<UserActiveSessionViewModel>());
    }

    [HttpPost("GetUserSessionsLog")]
    public async Task<IActionResult> GetUserSessionsLog([FromBody] UserSessionSearchModel searchModel)
    {
        return new JsonResult(
            await queryBusAsync.Dispatch<List<UserSessionViewModel>, UserSessionSearchModel>(searchModel));
    }

    [HttpGet("GetForCombo/{guid:guid}")]
    public IActionResult GetForCombo(Guid guid)
    {
        return new JsonResult(queryBus.Dispatch<List<UserComboModel>, Guid>(guid));
    }
}
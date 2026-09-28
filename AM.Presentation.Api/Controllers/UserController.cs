using AM.Application.Contracts.User;
using AM.Infrastructure.Query.Contract.User;
using AM.Presentation.Facade.Contract.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(
    IUserCommandFacade commandFacade,
    IUserQueryFacade queryFacade,
    IQueryBus queryBus) :
    ControllerBase
{
    [AllowAnonymous]
    [HttpPost("Login")]
    public UserViewModel Post([FromBody] Login command) => commandFacade.Login(command);

    [HttpPost("Create")]
    public void Post([FromBody] CreateUser command) => commandFacade.Create(command);

    [HttpPost("Deactivate/{guid:guid}")]
    public void Lock(Guid guid) => commandFacade.Lock(guid);

    [HttpPost("Activate/{guid:guid}")]
    public void Unlock(Guid guid) => commandFacade.Unlock(guid);

    [HttpGet("GetList")]
    public List<UserViewModel> Search() => queryFacade.GetList();

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) => commandFacade.Delete(guid);

    [HttpPost("OpenSession")]
    public void OpenSession([FromBody] OpenSession command)
    {
        command.ClientIpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        commandFacade.OpenSession(command);
    }

    [HttpGet("GetBy/{guid:guid}")]
    public EditUser GetBy(Guid guid) => queryFacade.GetBy(guid);

    [HttpPost("Edit")]
    public void Put([FromBody] EditUser command) => commandFacade.Edit(command);

    [HttpPost("ChangePassword")]
    public void ChangePassword(ChangePassword command) => commandFacade.ChangePassword(command);

    [AllowAnonymous]
    [HttpPost("CloseSessions/{guid:guid}")]
    public void CloseSessions(Guid guid) => commandFacade.CloseSession(guid);

    [HttpGet("GetForCombo")]
    public IActionResult GetForCombo() => new JsonResult(queryBus.Dispatch<List<UserComboModel>>());

    [HttpGet("GetForCombo/{guid:guid}")]
    public IActionResult GetForCombo(Guid guid) => new JsonResult(queryFacade.GetForCombo(guid));

    [HttpGet("GetUserInformation")]
    public async Task<IActionResult> GetUserInformation() => new JsonResult(await queryFacade.GetUserInformation());

    [HttpGet("GetCurrentUserLastSessions")]
    public async Task<IActionResult> GetCurrentUserLastSessions() =>
        new JsonResult(await queryFacade.GetCurrentUserLastSessions());

    [HttpGet("HasActiveSession")]
    public async Task<IActionResult> HasActiveSession() => new JsonResult(await queryFacade.HasActiveSession());

    [HttpPost("GetUserSessionsLog")]
    public async Task<IActionResult> GetUserSessionsLog([FromBody] UserSessionSearchModel searchModel) =>
        new JsonResult(await queryFacade.GetUserSessionsLog(searchModel));
}

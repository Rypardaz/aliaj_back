using AM.Application.Contracts.MachineLog;
using AM.Presentation.Facade.Contract.MachineLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class PackageDataController(IMachineLogCommandFacade machineLogCommandFacade) : ControllerBase
{
    [HttpPost("MachineLog")]
    public void Create([FromBody] CreateMachineLog command) => machineLogCommandFacade.Create(command);
}
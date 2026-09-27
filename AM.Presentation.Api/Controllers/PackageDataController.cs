using Microsoft.AspNetCore.Mvc;
using Lab.Presentation.Facade.Contract.MachineLog;
using Ex.Application.Contracts.MachineLog;
using Microsoft.AspNetCore.Authorization;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class PackageDataController(IMachineLogCommandFacade machineLogCommandFacade) : ControllerBase
{
    [HttpPost("MachineLog")]
    public void Create([FromBody] CreateMachineLog command) => machineLogCommandFacade.Create(command);
}
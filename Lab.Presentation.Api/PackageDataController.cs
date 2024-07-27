using Microsoft.AspNetCore.Mvc;
using Lab.Presentation.Facade.Contract.MachineLog;
using Ex.Application.Contracts.MachineLog;
using Microsoft.AspNetCore.Authorization;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PackageDataController : ControllerBase
    {
        private readonly IMachineLogCommandFacade _machineLogCommandFacade;

        public PackageDataController(IMachineLogCommandFacade machineLogCommandFacade)
        {
            _machineLogCommandFacade = machineLogCommandFacade;
        }

        [HttpPost("MachineLog")]
        public void Create([FromBody] CreateMachineLog command) => _machineLogCommandFacade.Create(command);
    }
}
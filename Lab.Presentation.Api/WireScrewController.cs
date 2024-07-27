using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.WireScrew;
using Lab.Presentation.Facade.Contract.WireScrew;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class WireScrewController : ControllerBase
    {
        private readonly IWireScrewCommandFacade _commandFacade;
        private readonly IWireScrewQueryFacade _queryFacade;

        public WireScrewController(IWireScrewCommandFacade commandFacade, IWireScrewQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateWireScrew command) =>
            new JsonResult(_commandFacade.Create(command));

        [HttpPost("Edit")]
        public void Edit([FromBody] EditWireScrew command) =>
            _commandFacade.Edit(command);

        [HttpPost("Delete/{guid:guid}")]
        public void Delete(Guid guid) =>
           _commandFacade.Delete(guid);

        [HttpPost("Activate/{guid:guid}")]
        public void Activate(Guid guid) =>
       _commandFacade.Activate(guid);

        [HttpPost("DeActivate/{guid:guid}")]
        public void DeActivate(Guid guid) =>
          _commandFacade.Deactivate(guid);

        [HttpGet("GetList")]
        public IActionResult List()
            => new JsonResult(_queryFacade.List());

        [HttpGet("GetForEdit/{guid:guid}")]
        public IActionResult GetDetails(Guid guid)
            => new JsonResult(_queryFacade.GetDetails(guid));

        [HttpGet("GetForCombo")]
        public IActionResult GetForCombo()
            => new JsonResult(_queryFacade.Combo());
    }
}
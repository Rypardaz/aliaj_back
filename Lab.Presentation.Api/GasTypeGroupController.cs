using Ex.Application.Contracts.GasTypeGroup;
using Lab.Presentation.Facade.Contract.GasTypeGroup;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class GasTypeGroupController : ControllerBase
    {

        private readonly IGasTypeGroupCommandFacade _commandFacade;
        private readonly IGasTypeGroupQueryFacade _queryFacade;

        public GasTypeGroupController(IGasTypeGroupCommandFacade commandFacade, IGasTypeGroupQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateGasTypeGroup command) =>
            new JsonResult(_commandFacade.Create(command));

        [HttpPost("Edit")]
        public void Edit([FromBody] EditGasTypeGroup command) =>
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

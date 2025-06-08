using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.Ticket;
using Lab.Infrastructure.Query.Contracts.Ticket;
using Lab.Presentation.Facade.Contract.Ticket;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketCommandFacade _commandFacade;
    private readonly ITicketQueryFacade _queryFacade;

    public TicketController(ITicketCommandFacade commandFacade, ITicketQueryFacade queryFacade)
    {
        _commandFacade = commandFacade;
        _queryFacade = queryFacade;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateTicket command) =>
        new JsonResult(_commandFacade.Create(command));

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) =>
        _commandFacade.Delete(guid);

    [HttpGet("GetList")]
    public IActionResult List([FromQuery] TicketSearchModel searchModel)
        => new JsonResult(_queryFacade.GetList(searchModel));

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid)
        => new JsonResult(_queryFacade.GetForEdit(guid));
}
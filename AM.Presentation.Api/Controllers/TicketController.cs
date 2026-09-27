using Microsoft.AspNetCore.Mvc;
using Ex.Application.Contracts.Ticket;
using Lab.Infrastructure.Query.Contracts.Ticket;
using Lab.Presentation.Facade.Contract.Ticket;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class TicketController(ITicketCommandFacade commandFacade, ITicketQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateTicket command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) =>
        commandFacade.Delete(guid);

    [HttpGet("GetList")]
    public IActionResult List([FromQuery] TicketSearchModel searchModel)
        => new JsonResult(queryFacade.GetList(searchModel));

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid)
        => new JsonResult(queryFacade.GetForEdit(guid));
}
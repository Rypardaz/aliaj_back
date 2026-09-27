using AM.Presentation.Facade.Contract.ListItem;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListItemController(IListItemQueryFacade queryFacade) : ControllerBase
{
    [HttpGet("GetForCombo/{listGroupId:int}")]
    public IActionResult GetForCombo(int listGroupId)
        => new JsonResult(queryFacade.GetForCombo(listGroupId));
}
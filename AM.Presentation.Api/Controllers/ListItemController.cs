using Microsoft.AspNetCore.Mvc;
using Lab.Presentation.Facade.Contract.ListItem;

namespace Lab.Presentation.Api;

[ApiController]
[Route("api/[controller]")]
public class ListItemController(IListItemQueryFacade queryFacade) : ControllerBase
{
    [HttpGet("GetForCombo/{listGroupId:int}")]
    public IActionResult GetForCombo(int listGroupId)
        => new JsonResult(queryFacade.GetForCombo(listGroupId));
}
using Microsoft.AspNetCore.Mvc;
using Lab.Presentation.Facade.Contract.ListItem;

namespace Lab.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListItemController : ControllerBase
    {

        private readonly IListItemQueryFacade _queryFacade;

        public ListItemController(IListItemQueryFacade queryFacade)
        {
            _queryFacade = queryFacade;
        }
        
        [HttpGet("GetForCombo/{listGroupId:int}")]
        public IActionResult GetForCombo(int listGroupId)
            => new JsonResult(_queryFacade.GetForCombo(listGroupId));
    }
}

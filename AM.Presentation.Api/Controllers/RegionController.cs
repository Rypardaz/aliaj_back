using Microsoft.AspNetCore.Mvc;
using AM.Presentation.Facade.Contract.Region;
using AM.Infrastructure.Query.Contract.Region;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegionController(IRegionQueryFacade queryFacade)
    : ControllerBase
{
    [HttpGet("GetList")]
    public async Task<IActionResult> GetList([FromQuery] RegionSearchModel searchModel)
        => new JsonResult(await queryFacade.GetList(searchModel));
}
using Microsoft.AspNetCore.Mvc;
using AM.Presentation.Facade.Contract.Feature;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeatureController(IFeatureQueryFacade queryFacade) : ControllerBase
{
    [HttpGet("GetUserPermissions")]
    public async Task<IActionResult> GetUserPermissions(Guid guid) =>
        new JsonResult(await queryFacade.GetUserPermissions());
}
using AM.Application.Contracts.ProjectDossier;
using AM.Presentation.Facade.Contract.ProjectDossier;
using Microsoft.AspNetCore.Mvc;

namespace AM.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectDossierController(IProjectDossierCommandFacade commandFacade, IProjectDossierQueryFacade queryFacade)
    : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateProjectDossier command) =>
        new JsonResult(commandFacade.Create(command));

    [HttpPost("Edit")]
    public void Edit([FromBody] EditProjectDossier command) =>
        commandFacade.Edit(command);

    [HttpPost("EditInquiryInformation")]
    public void EditInquiryInformation([FromBody] EditInquiryInformation command) =>
        commandFacade.EditInquiryInformation(command);

    [HttpPost("EditContractInformation")]
    public void EditContractInformation([FromBody] EditContractInformation command) =>
        commandFacade.EditContractInformation(command);

    [HttpPost("EditCost")]
    public void EditCost([FromBody] EditCost command) =>
        commandFacade.EditCost(command);

    [HttpPost("EditInvoice")]
    public void EditInvoice([FromBody] EditInvoice command) =>
        commandFacade.EditInvoice(command);

    [HttpPost("EditShippingEstimateHardface")]
    public void EditShippingEstimateHardface([FromBody] EditShippingEstimateHardface command) =>
        commandFacade.EditShippingEstimateHardface(command);

    [HttpPost("EditShippingEstimateRoller")]
    public void EditShippingEstimateRoller([FromBody] EditShippingEstimateRoller command) =>
        commandFacade.EditShippingEstimateRoller(command);

    [HttpPost("EditCostBeforImplementation")]
    public void EditCostBeforImplementation([FromBody] EditCostBeforImplementation command) =>
        commandFacade.EditCostBeforImplementation(command);

    [HttpPost("EditActualCost")]
    public void EditActualCost([FromBody] EditActualCost command) =>
        commandFacade.EditActualCost(command);


    [HttpPost("Delete/{guid:guid}")]
    public void Delete(Guid guid) =>
        commandFacade.Delete(guid);

    [HttpPost("Activate/{guid:guid}")]
    public void Activate(Guid guid) =>
        commandFacade.Activate(guid);

    [HttpPost("DeActivate/{guid:guid}")]
    public void DeActivate(Guid guid) =>
        commandFacade.Deactivate(guid);

    [HttpGet("GetList")]
    public IActionResult List()
        => new JsonResult(queryFacade.List());

    [HttpGet("GetForEdit/{guid:guid}")]
    public IActionResult GetDetails(Guid guid)
        => new JsonResult(queryFacade.GetDetails(guid));

    [HttpGet("GetForCombo/{salonGuid?}")]
    public IActionResult GetForCombo(Guid? salonGuid)
        => new JsonResult(queryFacade.Combo(salonGuid));
}

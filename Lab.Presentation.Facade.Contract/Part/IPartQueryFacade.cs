using Ex.Application.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Part;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Part
{
    public interface IPartQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<PartViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditPart GetDetails(Guid guid);
        List<PartComboModel> Combo();
    }
}

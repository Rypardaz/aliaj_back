using Ex.Application.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.PartGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PartGroup
{
    public interface IPartGroupQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<PartGroupViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditPartGroup GetDetails(Guid guid);
        List<PartGroupComboModel> Combo();
    }
}

using Ex.Application.Contracts.WireTypeGroup;
using Lab.Infrastructure.Query.Contracts.WireTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireTypeGroup
{
    public interface IWireTypeGroupQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<WireTypeGroupViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditWireTypeGroup GetDetails(Guid guid);
        List<WireTypeGroupComboModel> Combo();
    }
}

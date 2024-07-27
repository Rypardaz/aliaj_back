using Ex.Application.Contracts.GasTypeGroup;
using Lab.Infrastructure.Query.Contracts.GasTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.GasTypeGroup
{
    public interface IGasTypeGroupQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<GasTypeGroupViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditGasTypeGroup GetDetails(Guid guid);
        List<GasTypeGroupComboModel> Combo();
    }
}

using Ex.Application.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.GasType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.GasType
{
    public interface IGasTypeQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<GasTypeViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditGasType GetDetails(Guid guid);
        List<GasTypeComboModel> Combo();
    }
}

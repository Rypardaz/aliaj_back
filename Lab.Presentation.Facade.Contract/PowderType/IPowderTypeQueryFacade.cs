using Ex.Application.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.PowderType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PowderType
{
    public interface IPowderTypeQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<PowderTypeViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditPowderType GetDetails(Guid guid);
        List<PowderTypeComboModel> Combo();
    }
}

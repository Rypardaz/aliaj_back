using Ex.Application.Contracts.WireScrew;
using Lab.Infrastructure.Query.Contracts.WireScrew;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireScrew
{
    public interface IWireScrewQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<WireScrewViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditWireScrew GetDetails(Guid guid);
        List<WireScrewComboModel> Combo();
    }
}

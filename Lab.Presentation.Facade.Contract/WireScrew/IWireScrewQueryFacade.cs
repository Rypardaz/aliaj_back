using Ex.Application.Contracts.WireScrew;
using Lab.Infrastructure.Query.Contracts.WireScrew;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireScrew
{
    public interface IWireScrewQueryFacade : IFacadeService
    {
        List<WireScrewViewModel> List();
        EditWireScrew GetDetails(Guid guid);
        List<WireScrewComboModel> Combo();
    }
}

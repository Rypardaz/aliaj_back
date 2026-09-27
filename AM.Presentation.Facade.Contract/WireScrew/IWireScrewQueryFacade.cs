using AM.Application.Contracts.WireScrew;
using AM.Infrastructure.Query.Contract.WireScrew;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WireScrew;

public interface IWireScrewQueryFacade : IFacadeService
{
    List<WireScrewViewModel> List();
    EditWireScrew GetDetails(Guid guid);
    List<WireScrewComboModel> Combo();
    List<ProductionWireScrewViewModel> GetProductionWireScrews(ProductionWireScrewSearchModel searchModel);
}
using AM.Application.Contracts.WireScrew;
using AM.Infrastructure.Query.Contract.WireScrew;
using AM.Presentation.Facade.Contract.WireScrew;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class WireScrewQueryFacade(IQueryBus queryBus) : IWireScrewQueryFacade
{
    public EditWireScrew GetDetails(Guid guid) => queryBus.Dispatch<EditWireScrew, Guid>(guid);

    public List<WireScrewViewModel> List() => queryBus.Dispatch<List<WireScrewViewModel>>();

    public List<WireScrewComboModel> Combo() => queryBus.Dispatch<List<WireScrewComboModel>>();

    public List<ProductionWireScrewViewModel> GetProductionWireScrews(ProductionWireScrewSearchModel searchModel) =>
        queryBus.Dispatch<List<ProductionWireScrewViewModel>, ProductionWireScrewSearchModel>(searchModel);
}
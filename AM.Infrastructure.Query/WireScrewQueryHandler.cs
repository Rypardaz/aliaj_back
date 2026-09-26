using PhoenixFramework.Dapper;
using Ex.Application.Contracts.WireScrew;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.WireScrew;

namespace Lab.Infrastructure.Query;

public class WireScrewQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<WireScrewViewModel>>,
    IQueryHandler<EditWireScrew, Guid>,
    IQueryHandler<List<WireScrewComboModel>>,
    IQueryHandler<List<ProductionWireScrewViewModel>, ProductionWireScrewSearchModel>
{
    List<WireScrewViewModel> IQueryHandler<List<WireScrewViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<WireScrewViewModel>(QueryConstants.GetWireScrewFor, new
        {
            Type = QueryTypes.List
        });

    List<WireScrewComboModel> IQueryHandler<List<WireScrewComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<WireScrewComboModel>(QueryConstants.GetWireScrewFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditWireScrew Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditWireScrew>(QueryConstants.GetWireScrewFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

    public List<ProductionWireScrewViewModel> Handle(ProductionWireScrewSearchModel searchModel) =>
        dapperRepository.SelectFromSp<ProductionWireScrewViewModel>(QueryConstants.spGetProductionWireScrew,
            new { searchModel.Guid });
}
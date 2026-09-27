using AM.Application.Contracts.GasTypeGroup;
using AM.Infrastructure.Query.Contract.GasTypeGroup;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class GasTypeGroupQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<GasTypeGroupViewModel>>,
    IQueryHandler<EditGasTypeGroup, Guid>,
    IQueryHandler<List<GasTypeGroupComboModel>>
{
    List<GasTypeGroupViewModel> IQueryHandler<List<GasTypeGroupViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<GasTypeGroupViewModel>(QueryConstants.GetGasTypeGroupFor, new
        {
            Type = QueryTypes.List
        });

    List<GasTypeGroupComboModel> IQueryHandler<List<GasTypeGroupComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<GasTypeGroupComboModel>(QueryConstants.GetGasTypeGroupFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditGasTypeGroup Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditGasTypeGroup>(QueryConstants.GetGasTypeGroupFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
using Ex.Application.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

public class GasTypeQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<GasTypeViewModel>>,
    IQueryHandler<EditGasType, Guid>,
    IQueryHandler<List<GasTypeComboModel>>
{
    List<GasTypeViewModel> IQueryHandler<List<GasTypeViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<GasTypeViewModel>(QueryConstants.GetGasTypeFor, new
        {
            Type = QueryTypes.List
        });

    List<GasTypeComboModel> IQueryHandler<List<GasTypeComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<GasTypeComboModel>(QueryConstants.GetGasTypeFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditGasType Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditGasType>(QueryConstants.GetGasTypeFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
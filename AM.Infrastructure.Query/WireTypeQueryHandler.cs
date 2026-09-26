using Ex.Application.Contracts.WireType;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.WireType;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

public class WireTypeQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<WireTypeViewModel>>,
    IQueryHandler<EditWireType, Guid>,
    IQueryHandler<List<WireTypeComboModel>>
{
    List<WireTypeViewModel> IQueryHandler<List<WireTypeViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<WireTypeViewModel>(QueryConstants.GetWireTypeFor, new
        {
            Type = QueryTypes.List
        });

    List<WireTypeComboModel> IQueryHandler<List<WireTypeComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<WireTypeComboModel>(QueryConstants.GetWireTypeFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditWireType Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditWireType>(QueryConstants.GetWireTypeFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}
using AM.Application.Contracts.WireTypeGroup;
using AM.Infrastructure.Query.Contract.Shared;
using AM.Infrastructure.Query.Contract.WireTypeGroup;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class WireTypeGroupQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<WireTypeGroupViewModel>>,
    IQueryHandler<EditWireTypeGroup, Guid>,
    IQueryHandler<List<WireTypeGroupComboModel>>
{
    List<WireTypeGroupViewModel> IQueryHandler<List<WireTypeGroupViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<WireTypeGroupViewModel>(QueryConstants.GetWireTypeGroupFor, new
        {
            Type = QueryTypes.List
        });

    List<WireTypeGroupComboModel> IQueryHandler<List<WireTypeGroupComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<WireTypeGroupComboModel>(QueryConstants.GetWireTypeGroupFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditWireTypeGroup Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditWireTypeGroup>(QueryConstants.GetWireTypeGroupFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
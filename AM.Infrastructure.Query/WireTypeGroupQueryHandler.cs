using Ex.Application.Contracts.WireTypeGroup;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.WireTypeGroup;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

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
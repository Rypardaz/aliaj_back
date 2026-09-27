using AM.Application.Contracts.PowderTypeGroup;
using AM.Infrastructure.Query.Contract.PowderTypeGroup;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class PowderTypeGroupQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<PowderTypeGroupViewModel>>,
    IQueryHandler<EditPowderTypeGroup, Guid>,
    IQueryHandler<List<PowderTypeGroupComboModel>>
{
    List<PowderTypeGroupViewModel> IQueryHandler<List<PowderTypeGroupViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<PowderTypeGroupViewModel>(QueryConstants.GetPowderTypeGroupFor, new
        {
            Type = QueryTypes.List
        });

    List<PowderTypeGroupComboModel> IQueryHandler<List<PowderTypeGroupComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<PowderTypeGroupComboModel>(QueryConstants.GetPowderTypeGroupFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditPowderTypeGroup Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditPowderTypeGroup>(QueryConstants.GetPowderTypeGroupFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
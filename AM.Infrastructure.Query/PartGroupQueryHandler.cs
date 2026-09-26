using Ex.Application.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

public class PartGroupQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<PartGroupViewModel>>,
    IQueryHandler<EditPartGroup, Guid>,
    IQueryHandler<List<PartGroupComboModel>, Guid?>
{
    List<PartGroupViewModel> IQueryHandler<List<PartGroupViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<PartGroupViewModel>(QueryConstants.GetPartGroupFor, new
        {
            Type = QueryTypes.List
        });

    List<PartGroupComboModel> IQueryHandler<List<PartGroupComboModel>, Guid?>.Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<PartGroupComboModel>(QueryConstants.GetPartGroupFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }

    public EditPartGroup Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditPartGroup>(QueryConstants.GetPartGroupFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}
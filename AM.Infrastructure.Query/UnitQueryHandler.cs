using AM.Application.Contracts.Unit;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.Shared;
using AM.Infrastructure.Query.Contract.Unit;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class UnitQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<UnitViewModel>>,
    IQueryHandler<EditUnit, Guid>,
    IQueryHandler<List<UnitComboModel>, Guid?>
{
    List<UnitViewModel> IQueryHandler<List<UnitViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<UnitViewModel>(QueryConstants.GetUnitFor, new
        {
            Type = QueryTypes.List
        });

    public List<UnitComboModel> Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<UnitComboModel>(QueryConstants.GetUnitFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }
    public EditUnit Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditUnit>(QueryConstants.GetUnitFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}

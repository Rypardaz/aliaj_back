using AM.Application.Contracts.Material;
using AM.Infrastructure.Persist;
using AM.Infrastructure.Query.Contract.Material;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class MaterialQueryHandler(
    BaseDapperRepository dapperRepository,
    AliajQueryContext context) :
    IQueryHandler<List<MaterialViewModel>>,
    IQueryHandler<EditMaterial, Guid>,
    IQueryHandler<List<MaterialComboModel>, Guid?>
{
    List<MaterialViewModel> IQueryHandler<List<MaterialViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<MaterialViewModel>(QueryConstants.GetMaterialFor, new
        {
            Type = QueryTypes.List
        });

    public List<MaterialComboModel> Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<MaterialComboModel>(QueryConstants.GetMaterialFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }
    public EditMaterial Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditMaterial>(QueryConstants.GetMaterialFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });
}

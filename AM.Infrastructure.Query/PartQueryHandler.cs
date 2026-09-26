using Ex.Application.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

public class PartQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<PartViewModel>>,
    IQueryHandler<EditPart, Guid>,
    IQueryHandler<List<PartComboModel>, Guid?>
{
    List<PartViewModel> IQueryHandler<List<PartViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<PartViewModel>(QueryConstants.GetPartFor, new
        {
            Type = QueryTypes.List
        });

    List<PartComboModel> IQueryHandler<List<PartComboModel>, Guid?>.Handle(Guid? salonGuid)
    {
        return dapperRepository.SelectFromSp<PartComboModel>(QueryConstants.GetPartFor, new
        {
            Type = QueryTypes.Combo,
            SalonGuid = salonGuid
        });
    }

    public EditPart Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditPart>(QueryConstants.GetPartFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
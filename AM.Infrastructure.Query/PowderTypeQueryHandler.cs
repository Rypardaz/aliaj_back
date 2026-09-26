using Ex.Application.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

public class PowderTypeQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<PowderTypeViewModel>>,
    IQueryHandler<EditPowderType, Guid>,
    IQueryHandler<List<PowderTypeComboModel>>
{
    List<PowderTypeViewModel> IQueryHandler<List<PowderTypeViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<PowderTypeViewModel>(QueryConstants.GetPowderTypeFor, new
        {
            Type = QueryTypes.List
        });

    List<PowderTypeComboModel> IQueryHandler<List<PowderTypeComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<PowderTypeComboModel>(QueryConstants.GetPowderTypeFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditPowderType Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditPowderType>(QueryConstants.GetPowderTypeFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
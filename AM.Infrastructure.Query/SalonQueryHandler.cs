using AM.Application.Contracts.Salon;
using AM.Infrastructure.Query.Contract.Salon;
using AM.Infrastructure.Query.Contract.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;
using PhoenixFramework.Identity;

namespace AM.Infrastructure.Query;

public class SalonQueryHandler(BaseDapperRepository dapperRepository, IClaimHelper claimHelper)
    :
        IQueryHandler<List<SalonViewModel>>,
        IQueryHandler<EditSalon, Guid>,
        IQueryHandler<List<SalonComboModel>, int>
{
    List<SalonComboModel> IQueryHandler<List<SalonComboModel>, int>.Handle(int salonType)
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        return dapperRepository.SelectFromSp<SalonComboModel>(QueryConstants.GetSalonFor, new
        {
            Type = QueryTypes.Combo,
            SalonType = salonType,
            UserGuid = currentUserGuid
        });
    }

    public EditSalon Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditSalon>(QueryConstants.GetSalonFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

    List<SalonViewModel> IQueryHandler<List<SalonViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<SalonViewModel>(QueryConstants.GetSalonFor, new
        {
            Type = QueryTypes.List,
        });
}
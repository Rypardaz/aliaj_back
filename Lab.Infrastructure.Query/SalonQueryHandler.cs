using Ex.Application.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;
using PhoenixFramework.Identity;

namespace Lab.Infrastructure.Query
{
    public class SalonQueryHandler :
        IQueryHandler<List<SalonViewModel>>,
        IQueryHandler<EditSalon, Guid>,
        IQueryHandler<List<SalonComboModel>, int>
    {
        private readonly BaseDapperRepository _dapperRepository;
        private readonly IClaimHelper _claimHelper;

        public SalonQueryHandler(BaseDapperRepository dapperRepository, IClaimHelper claimHelper)
        {
            _dapperRepository = dapperRepository;
            _claimHelper = claimHelper;
        }

        List<SalonComboModel> IQueryHandler<List<SalonComboModel>, int>.Handle(int salonType)
        {
            var currentUserGuid = _claimHelper.GetCurrentUserGuid();
            return _dapperRepository.SelectFromSp<SalonComboModel>(QueryConstants.GetSalonFor, new
            {
                Type = QueryTypes.Combo,
                SalonType = salonType,
                UserGuid = currentUserGuid
            });
        }

        public EditSalon Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditSalon>(QueryConstants.GetSalonFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

        List<SalonViewModel> IQueryHandler<List<SalonViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<SalonViewModel>(QueryConstants.GetSalonFor, new
            {
                Type = QueryTypes.List,
            });
    }
}
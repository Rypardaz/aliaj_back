using Ex.Application.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class SalonQueryHandler :
        IQueryHandler<List<SalonViewModel>>,
        IQueryHandler<EditSalon, Guid>,
        IQueryHandler<List<SalonComboModel>, int>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public SalonQueryHandler(BaseDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        List<SalonComboModel> IQueryHandler<List<SalonComboModel>, int>.Handle(int salonType) =>
            _dapperRepository.SelectFromSp<SalonComboModel>(QueryConstants.GetSalonFor, new
            {
                Type = QueryTypes.Combo,
                SalonType = salonType
            });

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
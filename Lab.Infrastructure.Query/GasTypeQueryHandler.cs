using Ex.Application.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class GasTypeQueryHandler :
        IQueryHandler<List<GasTypeViewModel>>,
        IQueryHandler<EditGasType, Guid>,
        IQueryHandler<List<GasTypeComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public GasTypeQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<GasTypeViewModel> IQueryHandler<List<GasTypeViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<GasTypeViewModel>(QueryConstants.GetGasTypeFor, new
            {
                Type = QueryTypes.List
            });

        List<GasTypeComboModel> IQueryHandler<List<GasTypeComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<GasTypeComboModel>(QueryConstants.GetGasTypeFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditGasType Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditGasType>(QueryConstants.GetGasTypeFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

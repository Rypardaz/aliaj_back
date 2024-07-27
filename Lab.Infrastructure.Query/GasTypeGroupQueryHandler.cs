using Ex.Application.Contracts.GasTypeGroup;
using Lab.Infrastructure.Query.Contracts.GasTypeGroup;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class GasTypeGroupQueryHandler :
    IQueryHandler<List<GasTypeGroupViewModel>>,
    IQueryHandler<EditGasTypeGroup, Guid>,
    IQueryHandler<List<GasTypeGroupComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public GasTypeGroupQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<GasTypeGroupViewModel> IQueryHandler<List<GasTypeGroupViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<GasTypeGroupViewModel>(QueryConstants.GetGasTypeGroupFor, new
            {
                Type = QueryTypes.List
            });

        List<GasTypeGroupComboModel> IQueryHandler<List<GasTypeGroupComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<GasTypeGroupComboModel>(QueryConstants.GetGasTypeGroupFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditGasTypeGroup Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditGasTypeGroup>(QueryConstants.GetGasTypeGroupFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

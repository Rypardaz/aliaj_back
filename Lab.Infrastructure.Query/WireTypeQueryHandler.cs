using Ex.Application.Contracts.WireType;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.WireType;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class WireTypeQueryHandler :
    IQueryHandler<List<WireTypeViewModel>>,
    IQueryHandler<EditWireType, Guid>,
    IQueryHandler<List<WireTypeComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public WireTypeQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<WireTypeViewModel> IQueryHandler<List<WireTypeViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<WireTypeViewModel>(QueryConstants.GetWireTypeFor, new
            {
                Type = QueryTypes.List
            });

        List<WireTypeComboModel> IQueryHandler<List<WireTypeComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<WireTypeComboModel>(QueryConstants.GetWireTypeFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditWireType Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditWireType>(QueryConstants.GetWireTypeFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });
    }
}
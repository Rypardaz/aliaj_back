using Ex.Application.Contracts.WireTypeGroup;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.WireTypeGroup;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class WireTypeGroupQueryHandler :
    IQueryHandler<List<WireTypeGroupViewModel>>,
    IQueryHandler<EditWireTypeGroup, Guid>,
    IQueryHandler<List<WireTypeGroupComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public WireTypeGroupQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<WireTypeGroupViewModel> IQueryHandler<List<WireTypeGroupViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<WireTypeGroupViewModel>(QueryConstants.GetWireTypeGroupFor, new
            {
                Type = QueryTypes.List
            });

        List<WireTypeGroupComboModel> IQueryHandler<List<WireTypeGroupComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<WireTypeGroupComboModel>(QueryConstants.GetWireTypeGroupFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditWireTypeGroup Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditWireTypeGroup>(QueryConstants.GetWireTypeGroupFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

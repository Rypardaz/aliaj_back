using PhoenixFramework.Dapper;
using Ex.Application.Contracts.WireScrew;
using PhoenixFramework.Application.Query;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.WireScrew;

namespace Lab.Infrastructure.Query
{
    public class WireScrewQueryHandler :
        IQueryHandler<List<WireScrewViewModel>>,
        IQueryHandler<EditWireScrew, Guid>,
        IQueryHandler<List<WireScrewComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public WireScrewQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<WireScrewViewModel> IQueryHandler<List<WireScrewViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<WireScrewViewModel>(QueryConstants.GetWireScrewFor, new
            {
                Type = QueryTypes.List
            });

        List<WireScrewComboModel> IQueryHandler<List<WireScrewComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<WireScrewComboModel>(QueryConstants.GetWireScrewFor, new
            {
                Type = QueryTypes.Combo,
            });
        }

        public EditWireScrew Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditWireScrew>(QueryConstants.GetWireScrewFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });
    }
}

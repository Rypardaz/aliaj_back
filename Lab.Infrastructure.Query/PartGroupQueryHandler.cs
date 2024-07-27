using Ex.Application.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.PartGroup;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class PartGroupQueryHandler :
        IQueryHandler<List<PartGroupViewModel>>,
        IQueryHandler<EditPartGroup, Guid>,
        IQueryHandler<List<PartGroupComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public PartGroupQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<PartGroupViewModel> IQueryHandler<List<PartGroupViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<PartGroupViewModel>(QueryConstants.GetPartGroupFor, new
            {
                Type = QueryTypes.List
            });

        List<PartGroupComboModel> IQueryHandler<List<PartGroupComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<PartGroupComboModel>(QueryConstants.GetPartGroupFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditPartGroup Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditPartGroup>(QueryConstants.GetPartGroupFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Infrastructure.Query.Contracts.PowderTypeGroup;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class PowderTypeGroupQueryHandler :
    IQueryHandler<List<PowderTypeGroupViewModel>>,
    IQueryHandler<EditPowderTypeGroup, Guid>,
    IQueryHandler<List<PowderTypeGroupComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public PowderTypeGroupQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<PowderTypeGroupViewModel> IQueryHandler<List<PowderTypeGroupViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<PowderTypeGroupViewModel>(QueryConstants.GetPowderTypeGroupFor, new
            {
                Type = QueryTypes.List
            });

        List<PowderTypeGroupComboModel> IQueryHandler<List<PowderTypeGroupComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<PowderTypeGroupComboModel>(QueryConstants.GetPowderTypeGroupFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditPowderTypeGroup Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditPowderTypeGroup>(QueryConstants.GetPowderTypeGroupFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

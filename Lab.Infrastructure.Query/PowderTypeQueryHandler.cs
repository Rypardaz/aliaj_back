using Ex.Application.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class PowderTypeQueryHandler :
    IQueryHandler<List<PowderTypeViewModel>>,
    IQueryHandler<EditPowderType, Guid>,
    IQueryHandler<List<PowderTypeComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public PowderTypeQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<PowderTypeViewModel> IQueryHandler<List<PowderTypeViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<PowderTypeViewModel>(QueryConstants.GetPowderTypeFor, new
            {
                Type = QueryTypes.List
            });

        List<PowderTypeComboModel> IQueryHandler<List<PowderTypeComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<PowderTypeComboModel>(QueryConstants.GetPowderTypeFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditPowderType Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditPowderType>(QueryConstants.GetPowderTypeFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

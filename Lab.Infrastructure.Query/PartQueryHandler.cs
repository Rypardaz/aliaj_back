using Ex.Application.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Part;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class PartQueryHandler :
    IQueryHandler<List<PartViewModel>>,
    IQueryHandler<EditPart, Guid>,
    IQueryHandler<List<PartComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public PartQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<PartViewModel> IQueryHandler<List<PartViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<PartViewModel>(QueryConstants.GetPartFor, new
            {
                Type = QueryTypes.List
            });

        List<PartComboModel> IQueryHandler<List<PartComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<PartComboModel>(QueryConstants.GetPartFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditPart Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditPart>(QueryConstants.GetPartFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

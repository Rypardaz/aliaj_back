using Ex.Application.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Shared;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class ActivityQueryHandler :
    IQueryHandler<List<ActivityViewModel>>,
    IQueryHandler<EditActivity, Guid>,
    IQueryHandler<List<ActivityComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public ActivityQueryHandler(BaseDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        List<ActivityViewModel> IQueryHandler<List<ActivityViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<ActivityViewModel>(QueryConstants.GetActivityFor, new
            {
                Type = QueryTypes.List
            });

        public EditActivity Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditActivity>(QueryConstants.GetActivityFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

        public List<ActivityComboModel> Handle()
        {
            return _dapperRepository.SelectFromSp<ActivityComboModel>(QueryConstants.GetActivityFor, new
            {
                Type = QueryTypes.Combo
            });
        }
    }
}
using Ex.Application.Contracts.TaskMaster;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.TaskMaster;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query
{
    public class TaskMasterQueryHandler :
        IQueryHandler<List<TaskMasterViewModel>>,
        IQueryHandler<EditTaskMaster, Guid>,
        IQueryHandler<List<TaskMasterComboModel>>
    {
        private readonly BaseDapperRepository _dapperRepository;

        public TaskMasterQueryHandler(BaseDapperRepository dapperRepository)
        {

            _dapperRepository = dapperRepository;
        }

        List<TaskMasterViewModel> IQueryHandler<List<TaskMasterViewModel>>.Handle() =>
            _dapperRepository.SelectFromSp<TaskMasterViewModel>(QueryConstants.GetTaskMasterFor, new
            {
                Type = QueryTypes.List
            });

        List<TaskMasterComboModel> IQueryHandler<List<TaskMasterComboModel>>.Handle()
        {
            return _dapperRepository.SelectFromSp<TaskMasterComboModel>(QueryConstants.GetTaskMasterFor, new
            {
                Type = QueryTypes.Combo
            });
        }

        public EditTaskMaster Handle(Guid guid) =>
            _dapperRepository.SelectFromSpFirstOrDefault<EditTaskMaster>(QueryConstants.GetTaskMasterFor, new
            {
                Type = QueryTypes.Edit,
                Guid = guid
            });

    }
}

using AM.Application.Contracts.TaskMaster;
using AM.Infrastructure.Query.Contract.Shared;
using AM.Infrastructure.Query.Contract.TaskMaster;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class TaskMasterQueryHandler(BaseDapperRepository dapperRepository) :
    IQueryHandler<List<TaskMasterViewModel>>,
    IQueryHandler<EditTaskMaster, Guid>,
    IQueryHandler<List<TaskMasterComboModel>>
{
    List<TaskMasterViewModel> IQueryHandler<List<TaskMasterViewModel>>.Handle() =>
        dapperRepository.SelectFromSp<TaskMasterViewModel>(QueryConstants.GetTaskMasterFor, new
        {
            Type = QueryTypes.List
        });

    List<TaskMasterComboModel> IQueryHandler<List<TaskMasterComboModel>>.Handle()
    {
        return dapperRepository.SelectFromSp<TaskMasterComboModel>(QueryConstants.GetTaskMasterFor, new
        {
            Type = QueryTypes.Combo
        });
    }

    public EditTaskMaster Handle(Guid guid) =>
        dapperRepository.SelectFromSpFirstOrDefault<EditTaskMaster>(QueryConstants.GetTaskMasterFor, new
        {
            Type = QueryTypes.Edit,
            Guid = guid
        });

}
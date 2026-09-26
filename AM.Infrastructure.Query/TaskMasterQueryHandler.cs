using Ex.Application.Contracts.TaskMaster;
using Lab.Infrastructure.Query.Contracts.Shared;
using Lab.Infrastructure.Query.Contracts.TaskMaster;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace Lab.Infrastructure.Query;

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
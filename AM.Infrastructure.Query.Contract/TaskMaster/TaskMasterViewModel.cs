using PhoenixFramework.Company.Query;

namespace AM.Infrastructure.Query.Contract.TaskMaster;

public class TaskMasterViewModel : ViewModelAbilities
{
    public string Name { get; set; }
    public string IsActiveStr { get; set; }
}
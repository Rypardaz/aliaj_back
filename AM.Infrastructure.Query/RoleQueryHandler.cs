using AM.Application.Contracts.Role;
using AM.Infrastructure.Query.Contract.Role;
using PhoenixFramework.Application.Query;
using PhoenixFramework.Dapper;

namespace AM.Infrastructure.Query;

public class RoleQueryHandler(BaseDapperRepository repository) :
    IQueryHandler<EditRole, Guid>,
    IQueryHandler<List<RoleViewModel>>,
    IQueryHandler<List<RoleComboModel>>
{
    private const string RoleSpName = "spGetRoleFor";

    List<RoleViewModel> IQueryHandler<List<RoleViewModel>>.Handle()
    {
        return repository.SelectFromSp<RoleViewModel>(RoleSpName, new { Type = QueryOutputs.List });
    }

    public EditRole Handle(Guid guid)
    {
        return repository.SelectFromSpFirstOrDefault<EditRole>(RoleSpName,
            new { Type = QueryOutputs.Edit, guid });
    }

    List<RoleComboModel> IQueryHandler<List<RoleComboModel>>.Handle()
    {
        return repository.SelectFromSp<RoleComboModel>(RoleSpName, new { Type = QueryOutputs.Combo });
    }
}
using AM.Application.Contracts.Activity;
using AM.Infrastructure.Query.Contract.Activity;
using AM.Presentation.Facade.Contract.Activity;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class ActivityQueryFacade(IQueryBus queryBus) : IActivityQueryFacade
{
    public EditActivity GetDetails(Guid guid) => queryBus.Dispatch<EditActivity, Guid>(guid);

    public List<ActivityViewModel> List() => queryBus.Dispatch<List<ActivityViewModel>>();

    public List<ActivityComboModel> Combo(Guid? salonGuid) => 
        queryBus.Dispatch<List<ActivityComboModel>, Guid?>(salonGuid);
}

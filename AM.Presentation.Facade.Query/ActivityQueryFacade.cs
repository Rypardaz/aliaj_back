using Ex.Application.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Activity;
using Lab.Presentation.Facade.Contract.Activity;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class ActivityQueryFacade(IQueryBus queryBus) : IActivityQueryFacade
{
    public EditActivity GetDetails(Guid guid) => queryBus.Dispatch<EditActivity, Guid>(guid);

    public List<ActivityViewModel> List() => queryBus.Dispatch<List<ActivityViewModel>>();

    public List<ActivityComboModel> Combo(Guid? salonGuid) => 
        queryBus.Dispatch<List<ActivityComboModel>, Guid?>(salonGuid);
}
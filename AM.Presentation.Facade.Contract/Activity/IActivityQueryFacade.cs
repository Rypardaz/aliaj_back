using AM.Application.Contracts.Activity;
using AM.Infrastructure.Query.Contract.Activity;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Activity;

public interface IActivityQueryFacade : IFacadeService
{
    List<ActivityViewModel> List();
        
    EditActivity GetDetails(Guid guid);
    List<ActivityComboModel> Combo(Guid? salonGuid);
}
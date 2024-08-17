using Ex.Application.Contracts.Activity;
using Lab.Infrastructure.Query.Contracts.Activity;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Activity
{
    public interface IActivityQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<ActivityViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditActivity GetDetails(Guid guid);
        List<ActivityComboModel> Combo(Guid? salonGuid);
    }
}

using Ex.Application.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Salon;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Salon
{
    public interface ISalonQueryFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType")]
        List<SalonViewModel> List();
        [HasPermission("BasicInformation_OperationType_Edit")]
        EditSalon GetDetails(Guid guid);
        List<SalonComboModel> Combo();
    }
}

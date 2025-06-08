using Ex.Application.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Salon;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Salon
{
    public interface ISalonQueryFacade : IFacadeService
    {
        List<SalonViewModel> List();
        EditSalon GetDetails(Guid guid);
        List<SalonComboModel> Combo(int salonType);
    }
}

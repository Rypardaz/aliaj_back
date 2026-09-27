using AM.Application.Contracts.Salon;
using AM.Infrastructure.Query.Contract.Salon;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Salon;

public interface ISalonQueryFacade : IFacadeService
{
    List<SalonViewModel> List();
    EditSalon GetDetails(Guid guid);
    List<SalonComboModel> Combo(int salonType);
}
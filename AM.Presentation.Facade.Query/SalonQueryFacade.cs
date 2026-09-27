using AM.Application.Contracts.Salon;
using AM.Infrastructure.Query.Contract.Salon;
using AM.Presentation.Facade.Contract.Salon;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class SalonQueryFacade(IQueryBus queryBus) : ISalonQueryFacade
{
    public EditSalon GetDetails(Guid guid) => queryBus.Dispatch<EditSalon, Guid>(guid);

    public List<SalonViewModel> List() => queryBus.Dispatch<List<SalonViewModel>>();

    public List<SalonComboModel> Combo(int salonType) => queryBus.Dispatch<List<SalonComboModel>, int>(salonType);
}
using Ex.Application.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Salon;
using Lab.Presentation.Facade.Contract.Salon;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class SalonQueryFacade(IQueryBus queryBus) : ISalonQueryFacade
{
    public EditSalon GetDetails(Guid guid) => queryBus.Dispatch<EditSalon, Guid>(guid);

    public List<SalonViewModel> List() => queryBus.Dispatch<List<SalonViewModel>>();

    public List<SalonComboModel> Combo(int salonType) => queryBus.Dispatch<List<SalonComboModel>, int>(salonType);
}
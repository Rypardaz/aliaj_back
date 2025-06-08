using Ex.Application.Contracts.Salon;
using Lab.Infrastructure.Query.Contracts.Salon;
using Lab.Presentation.Facade.Contract.Salon;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class SalonQueryFacade : ISalonQueryFacade
{
    private readonly IQueryBus _queryBus;

    public SalonQueryFacade(IQueryBus queryBus) => _queryBus = queryBus;

    public EditSalon GetDetails(Guid guid) => _queryBus.Dispatch<EditSalon, Guid>(guid);

    public List<SalonViewModel> List() => _queryBus.Dispatch<List<SalonViewModel>>();

    public List<SalonComboModel> Combo(int salonType) => _queryBus.Dispatch<List<SalonComboModel>, int>(salonType);
}
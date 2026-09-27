using AM.Application.Contracts.PowderTypeGroup;
using AM.Infrastructure.Query.Contract.PowderTypeGroup;
using AM.Presentation.Facade.Contract.PowderTypeGroup;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class PowderTypeGroupQueryFacade(IQueryBus queryBus) : IPowderTypeGroupQueryFacade
{
    public EditPowderTypeGroup GetDetails(Guid guid) => queryBus.Dispatch<EditPowderTypeGroup, Guid>(guid);

    public List<PowderTypeGroupViewModel> List() => queryBus.Dispatch<List<PowderTypeGroupViewModel>>();

    public List<PowderTypeGroupComboModel> Combo() => queryBus.Dispatch<List<PowderTypeGroupComboModel>>();
}
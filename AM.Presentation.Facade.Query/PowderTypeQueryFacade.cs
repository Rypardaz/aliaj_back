using AM.Application.Contracts.PowderType;
using AM.Infrastructure.Query.Contract.PowderType;
using AM.Presentation.Facade.Contract.PowderType;
using PhoenixFramework.Application.Query;

namespace AM.Presentation.Facade.Query;

public class PowderTypeQueryFacade(IQueryBus queryBus) : IPowderTypeQueryFacade
{
    public EditPowderType GetDetails(Guid guid) => queryBus.Dispatch<EditPowderType, Guid>(guid);

    public List<PowderTypeViewModel> List() => queryBus.Dispatch<List<PowderTypeViewModel>>();

    public List<PowderTypeComboModel> Combo() => queryBus.Dispatch<List<PowderTypeComboModel>>();
}
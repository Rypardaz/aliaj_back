using Ex.Application.Contracts.PowderTypeGroup;
using Lab.Infrastructure.Query.Contracts.PowderTypeGroup;
using Lab.Presentation.Facade.Contract.PowderTypeGroup;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class PowderTypeGroupQueryFacade(IQueryBus queryBus) : IPowderTypeGroupQueryFacade
{
    public EditPowderTypeGroup GetDetails(Guid guid) => queryBus.Dispatch<EditPowderTypeGroup, Guid>(guid);

    public List<PowderTypeGroupViewModel> List() => queryBus.Dispatch<List<PowderTypeGroupViewModel>>();

    public List<PowderTypeGroupComboModel> Combo() => queryBus.Dispatch<List<PowderTypeGroupComboModel>>();
}
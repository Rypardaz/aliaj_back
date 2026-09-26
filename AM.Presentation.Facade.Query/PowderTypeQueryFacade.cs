using Ex.Application.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.PowderType;
using Lab.Presentation.Facade.Contract.PowderType;
using PhoenixFramework.Application.Query;

namespace Lab.Presentation.Facade.Query;

public class PowderTypeQueryFacade(IQueryBus queryBus) : IPowderTypeQueryFacade
{
    public EditPowderType GetDetails(Guid guid) => queryBus.Dispatch<EditPowderType, Guid>(guid);

    public List<PowderTypeViewModel> List() => queryBus.Dispatch<List<PowderTypeViewModel>>();

    public List<PowderTypeComboModel> Combo() => queryBus.Dispatch<List<PowderTypeComboModel>>();
}
using AM.Application.Contracts.PowderTypeGroup;
using AM.Infrastructure.Query.Contract.PowderTypeGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.PowderTypeGroup;

public interface IPowderTypeGroupQueryFacade : IFacadeService
{
    List<PowderTypeGroupViewModel> List();
    EditPowderTypeGroup GetDetails(Guid guid);
    List<PowderTypeGroupComboModel> Combo();
}
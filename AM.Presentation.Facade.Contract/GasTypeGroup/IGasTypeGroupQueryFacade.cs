using AM.Application.Contracts.GasTypeGroup;
using AM.Infrastructure.Query.Contract.GasTypeGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.GasTypeGroup;

public interface IGasTypeGroupQueryFacade : IFacadeService
{
    List<GasTypeGroupViewModel> List();
    EditGasTypeGroup GetDetails(Guid guid);
    List<GasTypeGroupComboModel> Combo();
}
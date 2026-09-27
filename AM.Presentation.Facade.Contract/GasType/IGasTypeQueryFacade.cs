using AM.Application.Contracts.GasType;
using AM.Infrastructure.Query.Contract.GasType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.GasType;

public interface IGasTypeQueryFacade : IFacadeService
{
        
    List<GasTypeViewModel> List();
        
    EditGasType GetDetails(Guid guid);
    List<GasTypeComboModel> Combo();
}
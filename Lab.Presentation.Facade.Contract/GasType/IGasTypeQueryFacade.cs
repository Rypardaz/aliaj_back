using Ex.Application.Contracts.GasType;
using Lab.Infrastructure.Query.Contracts.GasType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.GasType
{
    public interface IGasTypeQueryFacade : IFacadeService
    {
        
        List<GasTypeViewModel> List();
        
        EditGasType GetDetails(Guid guid);
        List<GasTypeComboModel> Combo();
    }
}

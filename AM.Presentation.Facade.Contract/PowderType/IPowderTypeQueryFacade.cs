using AM.Application.Contracts.PowderType;
using AM.Infrastructure.Query.Contract.PowderType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.PowderType;

public interface IPowderTypeQueryFacade : IFacadeService
{
        
    List<PowderTypeViewModel> List();
        
    EditPowderType GetDetails(Guid guid);
    List<PowderTypeComboModel> Combo();
}
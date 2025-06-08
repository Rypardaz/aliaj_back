using Ex.Application.Contracts.PowderType;
using Lab.Infrastructure.Query.Contracts.PowderType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PowderType
{
    public interface IPowderTypeQueryFacade : IFacadeService
    {
        
        List<PowderTypeViewModel> List();
        
        EditPowderType GetDetails(Guid guid);
        List<PowderTypeComboModel> Combo();
    }
}

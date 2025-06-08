using Ex.Application.Contracts.WireType;
using Lab.Infrastructure.Query.Contracts.WireType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireType
{
    public interface IWireTypeQueryFacade : IFacadeService
    {
        
        List<WireTypeViewModel> List();
        
        EditWireType GetDetails(Guid guid);
        List<WireTypeComboModel> Combo();
    }
}

using Ex.Application.Contracts.WireTypeGroup;
using Lab.Infrastructure.Query.Contracts.WireTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireTypeGroup
{
    public interface IWireTypeGroupQueryFacade : IFacadeService
    {
        
        List<WireTypeGroupViewModel> List();
        
        EditWireTypeGroup GetDetails(Guid guid);
        List<WireTypeGroupComboModel> Combo();
    }
}

using AM.Application.Contracts.WireTypeGroup;
using AM.Infrastructure.Query.Contract.WireTypeGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WireTypeGroup;

public interface IWireTypeGroupQueryFacade : IFacadeService
{
        
    List<WireTypeGroupViewModel> List();
        
    EditWireTypeGroup GetDetails(Guid guid);
    List<WireTypeGroupComboModel> Combo();
}
using AM.Application.Contracts.WireType;
using AM.Infrastructure.Query.Contract.WireType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WireType;

public interface IWireTypeQueryFacade : IFacadeService
{
        
    List<WireTypeViewModel> List();
        
    EditWireType GetDetails(Guid guid);
    List<WireTypeComboModel> Combo();
}
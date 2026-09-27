using AM.Application.Contracts.WireType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WireType;

public interface IWireTypeCommandFacade : IFacadeService
{
        
    Guid Create(CreateWireType command);
        
    void Edit(EditWireType command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
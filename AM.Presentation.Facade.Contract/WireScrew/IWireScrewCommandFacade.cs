using AM.Application.Contracts.WireScrew;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.WireScrew;

public interface IWireScrewCommandFacade : IFacadeService
{
        
    Guid Create(CreateWireScrew command);
        
    void Edit(EditWireScrew command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
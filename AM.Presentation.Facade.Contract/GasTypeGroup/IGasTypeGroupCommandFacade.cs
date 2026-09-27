using AM.Application.Contracts.GasTypeGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.GasTypeGroup;

public interface IGasTypeGroupCommandFacade : IFacadeService
{
        
    Guid Create(CreateGasTypeGroup command);
        
    void Edit(EditGasTypeGroup command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
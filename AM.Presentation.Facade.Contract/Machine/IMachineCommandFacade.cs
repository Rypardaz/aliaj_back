using AM.Application.Contracts.Machine;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Machine;

public interface IMachineCommandFacade : IFacadeService
{
        
    Guid Create(CreateMachine command);
        
    void Edit(EditMachine command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
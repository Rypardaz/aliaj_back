using AM.Application.Contracts.PowderTypeGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.PowderTypeGroup;

public interface IPowderTypeGroupCommandFacade : IFacadeService
{
        
    Guid Create(CreatePowderTypeGroup command);
        
    void Edit(EditPowderTypeGroup command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
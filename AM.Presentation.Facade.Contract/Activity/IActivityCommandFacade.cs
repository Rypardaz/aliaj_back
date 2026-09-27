using AM.Application.Contracts.Activity;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Activity;

public interface IActivityCommandFacade : IFacadeService
{
        
    Guid Create(CreateActivity command);
        
    void Edit(EditActivity command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
using AM.Application.Contracts.Salon;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Salon;

public interface ISalonCommandFacade : IFacadeService
{
        
    Guid Create(CreateSalon command);
        
    void Edit(EditSalon command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
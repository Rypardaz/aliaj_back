using AM.Application.Contracts.Part;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Part;

public interface IPartCommandFacade : IFacadeService
{
        
    Task<Guid> Create(CreatePart command);
        
    Task Edit(EditPart command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
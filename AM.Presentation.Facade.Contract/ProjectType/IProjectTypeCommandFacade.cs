using AM.Application.Contracts.ProjectType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.ProjectType;

public interface IProjectTypeCommandFacade : IFacadeService
{
        
    Task<Guid> Create(CreateProjectType command);
        
    Task Edit(EditProjectType command);
        
    void Delete(Guid guid);
        
    void Activate(Guid guid);
        
    void Deactivate(Guid guid);
}
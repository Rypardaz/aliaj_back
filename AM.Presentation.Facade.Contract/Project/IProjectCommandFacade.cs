using AM.Application.Contracts.Project;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Project;

public interface IProjectCommandFacade : IFacadeService
{
    Guid Create(CreateProject command);
    void Edit(EditProject command);
    void Delete(Guid guid);
}
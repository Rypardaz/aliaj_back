using PhoenixFramework.Core;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Project;

namespace Lab.Presentation.Facade.Contract.Project
{
    public interface IProjectCommandFacade : IFacadeService
    {
        Guid Create(CreateProject command);
        void Edit(EditProject command);
        void Delete(Guid guid);
    }
}

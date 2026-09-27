using AM.Application.Contracts.Personnel;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Personnel;

public interface IPersonnelCommandFacade : IFacadeService
{
    Task<Guid> Create(CreatePersonnel command);
    Task Edit(EditPersonnel command);
    void Delete(Guid guid);
    void Activate(Guid guid);
    void Deactivate(Guid guid);
}
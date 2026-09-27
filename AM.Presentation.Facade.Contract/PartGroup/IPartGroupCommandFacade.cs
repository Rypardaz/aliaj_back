using AM.Application.Contracts.PartGroup;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.PartGroup;

public interface IPartGroupCommandFacade : IFacadeService
{
    Guid Create(CreatePartGroup command);
    void Edit(EditPartGroup command);
    void Delete(Guid guid);
    void Activate(Guid guid);
    void Deactivate(Guid guid);
}
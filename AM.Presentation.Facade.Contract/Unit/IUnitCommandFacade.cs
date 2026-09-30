using AM.Application.Contracts.Unit;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.Unit;

public interface IUnitCommandFacade : IFacadeService
{

    Guid Create(CreateUnit command);

    void Edit(EditUnit command);

    void Delete(Guid guid);

    void Activate(Guid guid);

    void Deactivate(Guid guid);
}

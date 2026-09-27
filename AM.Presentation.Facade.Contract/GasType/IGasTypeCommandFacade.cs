using AM.Application.Contracts.GasType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.GasType;

public interface IGasTypeCommandFacade : IFacadeService
{
    Guid Create(CreateGasType command);
    void Edit(EditGasType command);
    void Delete(Guid guid);
    void Activate(Guid guid);
    void Deactivate(Guid guid);
}
using AM.Application.Contracts.PowderType;
using PhoenixFramework.Core;

namespace AM.Presentation.Facade.Contract.PowderType;

public interface IPowderTypeCommandFacade : IFacadeService
{
    Guid Create(CreatePowderType command);
    void Edit(EditPowderType command);
    void Delete(Guid guid);
    void Activate(Guid guid);
    void Deactivate(Guid guid);
}
using Ex.Application.Contracts.PowderType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PowderType
{
    public interface IPowderTypeCommandFacade : IFacadeService
    {
        Guid Create(CreatePowderType command);
        void Edit(EditPowderType command);
        void Delete(Guid guid);
        void Activate(Guid guid);
        void Deactivate(Guid guid);
    }
}

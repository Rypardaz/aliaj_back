using Ex.Application.Contracts.PowderTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.PowderTypeGroup
{
    public interface IPowderTypeGroupCommandFacade : IFacadeService
    {
        
        Guid Create(CreatePowderTypeGroup command);
        
        void Edit(EditPowderTypeGroup command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

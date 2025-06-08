using Ex.Application.Contracts.WireScrew;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireScrew
{
    public interface IWireScrewCommandFacade : IFacadeService
    {
        
        Guid Create(CreateWireScrew command);
        
        void Edit(EditWireScrew command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

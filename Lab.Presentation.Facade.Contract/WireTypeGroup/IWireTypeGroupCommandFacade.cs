using Ex.Application.Contracts.WireTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireTypeGroup
{
    public interface IWireTypeGroupCommandFacade : IFacadeService
    {
        
        Guid Create(CreateWireTypeGroup command);
        
        void Edit(EditWireTypeGroup command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

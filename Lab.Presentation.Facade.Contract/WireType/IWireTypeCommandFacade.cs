using Ex.Application.Contracts.WireType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireType
{
    public interface IWireTypeCommandFacade : IFacadeService
    {
        
        Guid Create(CreateWireType command);
        
        void Edit(EditWireType command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

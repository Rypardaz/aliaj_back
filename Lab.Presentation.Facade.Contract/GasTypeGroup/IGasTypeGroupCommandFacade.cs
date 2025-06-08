using Ex.Application.Contracts.GasTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.GasTypeGroup
{
    public interface IGasTypeGroupCommandFacade : IFacadeService
    {
        
        Guid Create(CreateGasTypeGroup command);
        
        void Edit(EditGasTypeGroup command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

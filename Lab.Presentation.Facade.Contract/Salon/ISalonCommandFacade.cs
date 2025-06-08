using Ex.Application.Contracts.Salon;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Salon
{
    public interface ISalonCommandFacade : IFacadeService
    {
        
        Guid Create(CreateSalon command);
        
        void Edit(EditSalon command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

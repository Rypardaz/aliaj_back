using Ex.Application.Contracts.Part;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Part
{
    public interface IPartCommandFacade : IFacadeService
    {
        
        Task<Guid> Create(CreatePart command);
        
        Task Edit(EditPart command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

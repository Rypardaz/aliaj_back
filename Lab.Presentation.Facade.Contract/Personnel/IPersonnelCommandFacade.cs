using Ex.Application.Contracts.Personnel;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Personnel
{
    public interface IPersonnelCommandFacade : IFacadeService
    {
        Task<Guid> Create(CreatePersonnel command);
        Task Edit(EditPersonnel command);
        void Delete(Guid guid);
        void Activate(Guid guid);
        void Deactivate(Guid guid);
    }
}

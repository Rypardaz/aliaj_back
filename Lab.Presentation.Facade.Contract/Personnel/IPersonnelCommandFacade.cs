using Ex.Application.Contracts.Personnel;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Personnel
{
    public interface IPersonnelCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Task<Guid> Create(CreatePersonnel command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        Task Edit(EditPersonnel command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

using Ex.Application.Contracts.Part;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Part
{
    public interface IPartCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Task<Guid> Create(CreatePart command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        Task Edit(EditPart command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

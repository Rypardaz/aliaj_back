using Ex.Application.Contracts.WireTypeGroup;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireTypeGroup
{
    public interface IWireTypeGroupCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Guid Create(CreateWireTypeGroup command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        void Edit(EditWireTypeGroup command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

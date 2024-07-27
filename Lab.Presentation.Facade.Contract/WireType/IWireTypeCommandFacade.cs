using Ex.Application.Contracts.WireType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.WireType
{
    public interface IWireTypeCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Guid Create(CreateWireType command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        void Edit(EditWireType command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

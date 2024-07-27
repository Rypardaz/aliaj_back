using Ex.Application.Contracts.Machine;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Machine
{
    public interface IMachineCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Guid Create(CreateMachine command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        void Edit(EditMachine command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

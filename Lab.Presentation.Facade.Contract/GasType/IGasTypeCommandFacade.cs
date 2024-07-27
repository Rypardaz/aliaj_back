using Ex.Application.Contracts.GasType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.GasType
{
    public interface IGasTypeCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Guid Create(CreateGasType command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        void Edit(EditGasType command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

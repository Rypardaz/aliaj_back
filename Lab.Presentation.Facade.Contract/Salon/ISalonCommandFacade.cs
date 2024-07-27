using Ex.Application.Contracts.Salon;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;

namespace Lab.Presentation.Facade.Contract.Salon
{
    public interface ISalonCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Guid Create(CreateSalon command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        void Edit(EditSalon command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

using PhoenixFramework.Core;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.Project;

namespace Lab.Presentation.Facade.Contract.Project
{
    public interface IProjectCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Guid Create(CreateProject command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        void Edit(EditProject command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
    }
}

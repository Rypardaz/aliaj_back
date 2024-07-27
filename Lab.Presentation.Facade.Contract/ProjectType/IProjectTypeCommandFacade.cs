using Ex.Application.Contracts.ProjectType;
using PhoenixFramework.Core;
using PhoenixFramework.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Presentation.Facade.Contract.ProjectType
{
    public interface IProjectTypeCommandFacade : IFacadeService
    {
        [HasPermission("BasicInformation_OperationType_New")]
        Task<Guid> Create(CreateProjectType command);
        [HasPermission("BasicInformation_OperationType_Edit")]
        Task Edit(EditProjectType command);
        [HasPermission("BasicInformation_OperationType_Delete")]
        void Delete(Guid guid);
        [HasPermission("BasicInformation_OperationType_Activate")]
        void Activate(Guid guid);
        [HasPermission("BasicInformation_OperationType_Deactivate")]
        void Deactivate(Guid guid);
    }
}

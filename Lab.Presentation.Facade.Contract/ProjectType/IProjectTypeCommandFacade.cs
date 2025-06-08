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
        
        Task<Guid> Create(CreateProjectType command);
        
        Task Edit(EditProjectType command);
        
        void Delete(Guid guid);
        
        void Activate(Guid guid);
        
        void Deactivate(Guid guid);
    }
}

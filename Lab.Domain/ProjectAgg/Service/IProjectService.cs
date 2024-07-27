using Ex.Application.Contracts.Project;
using PhoenixFramework.Core;

namespace Ex.Domain.ProjectAgg.Service
{
    public interface IProjectService : IDomainService
    {
        void SetDetails(Project project, List<ProjectDetailOperations> details);
    }
}

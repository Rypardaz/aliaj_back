using AM.Application.Contracts.Project;
using PhoenixFramework.Core;

namespace AM.Domain.ProjectAgg.Service;

public interface IProjectService : IDomainService
{
    void SetDetails(Project project, List<ProjectDetailOperations> details);
}
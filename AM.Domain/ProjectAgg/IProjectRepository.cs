using PhoenixFramework.Domain;

namespace AM.Domain.ProjectAgg;

public interface IProjectRepository : IRepository<long, Project>
{
    long DetailIdBy(Guid detailGuid);
}
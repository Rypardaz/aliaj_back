using PhoenixFramework.Domain;

namespace Ex.Domain.ProjectAgg
{
    public interface IProjectRepository : IRepository<long, Project>
    {
        long DetailIdBy(Guid detailGuid);
    }
}

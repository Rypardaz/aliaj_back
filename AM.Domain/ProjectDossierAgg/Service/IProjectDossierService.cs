using PhoenixFramework.Core;

namespace AM.Domain.ProjectDossierAgg.Service;

public interface IProjectDossierService : IDomainService
{
    void ThrowWhenDuplicatedProjectCode(string projectCode, long? id = null);
    void ThrowWhenDuplicatedNo(string No, long? id = null);
    void ThrowWhenRecordNotFound(long id);
}
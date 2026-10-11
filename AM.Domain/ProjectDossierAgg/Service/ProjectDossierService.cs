using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;
using System.Linq.Expressions;

namespace AM.Domain.ProjectDossierAgg.Service;

public class ProjectDossierService(IProjectDossierRepository projectDossierRepository) : IProjectDossierService
{
    private Expression<Func<ProjectDossier, bool>>? _predicate;

    public void ThrowWhenDuplicatedProjectCode(string projectCode, long? id = null)
    {
        _predicate = x => x.ProjectCode == projectCode;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (projectDossierRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenDuplicatedNo(string no, long? id = null)
    {
        _predicate = x => x.No == no;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (projectDossierRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!projectDossierRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
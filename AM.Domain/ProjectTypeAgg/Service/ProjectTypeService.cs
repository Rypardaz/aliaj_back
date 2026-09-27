using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.ProjectTypeAgg.Service;

public class ProjectTypeService(IProjectTypeRepository projectTypeRepository) : IProjectTypeService
{
    private Expression<Func<ProjectType, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(long salonId, string name, long? id = null)
    {
        _predicate = x => x.Name == name;
        _predicate = _predicate.And(x => x.SalonId == salonId);

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (projectTypeRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!projectTypeRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
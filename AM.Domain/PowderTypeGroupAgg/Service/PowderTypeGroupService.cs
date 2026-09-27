using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.PowderTypeGroupAgg.Service;

public class PowderTypeGroupService(IPowderTypeGroupRepository powderTypeGroupRepository) : IPowderTypeGroupService
{
    private Expression<Func<PowderTypeGroup, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(string name, long? id = null)
    {
        _predicate = x => x.Name == name;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (powderTypeGroupRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!powderTypeGroupRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
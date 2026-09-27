using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.PowderTypeAgg.Service;

public class PowderTypeService(IPowderTypeRepository powderTypeRepository) : IPowderTypeService
{
    private Expression<Func<PowderType, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(long powderTypeGroupId, string name, long? id = null)
    {
        _predicate = x => x.PowderTypeGroupId == powderTypeGroupId;
        _predicate = _predicate.And(x => x.Name == name);

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (powderTypeRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!powderTypeRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
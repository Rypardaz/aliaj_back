using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;
using System.Linq.Expressions;

namespace Ex.Domain.GasTypeGroupAgg.Service;

public class GasTypeGroupService(IGasTypeGroupRepository gasTypeGroupRepository) : IGasTypeGroupService
{
    private Expression<Func<GasTypeGroup, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(string name, long? id = null)
    {
        _predicate = x => x.Name == name;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (gasTypeGroupRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!gasTypeGroupRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
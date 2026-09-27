using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.GasTypeAgg.Service;

public class GasTypeService(IGasTypeRepository gasTypeRepository) : IGasTypeService
{
    private Expression<Func<GasType, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(long gasTypeGroupId, string name, long? id = null)
    {
        _predicate = x => x.GasTypeGroupId == gasTypeGroupId;
        _predicate = _predicate.And(x => x.Name == name);

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (gasTypeRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!gasTypeRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
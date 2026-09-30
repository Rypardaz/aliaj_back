using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.UnitAgg.Service;

public class UnitService(IUnitRepository UnitRepository) : IUnitService
{
    private Expression<Func<Unit, bool>>? _predicate;

    public void ThrowWhenDuplicatedCode(string code, long? id = null)
    {
        _predicate = x => x.Code == code;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (UnitRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenDuplicatedName(string name, long? id = null)
    {
        _predicate = x => x.Name == name;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (UnitRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!UnitRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
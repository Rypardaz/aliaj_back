using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.PartAgg.Service;

public class PartService(IPartRepository partRepository) : IPartService
{
    private Expression<Func<Part, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(long partGroupId, string name, long? id = null)
    {
        _predicate = x => x.PartGroupId == partGroupId && x.Name == name;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (partRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!partRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
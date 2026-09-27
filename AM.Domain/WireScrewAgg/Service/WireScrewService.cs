using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.WireScrewAgg.Service;

public class WireScrewService(IWireScrewRepository wireScrewRepository) : IWireScrewService
{
    private Expression<Func<WireScrew, bool>>? _predicate;

    public void ThrowWhenDuplicatedScrew(int screw, long? id = null)
    {
        _predicate = x => x.Screw == screw;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (wireScrewRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!wireScrewRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
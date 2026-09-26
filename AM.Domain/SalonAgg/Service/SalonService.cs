using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;


namespace Ex.Domain.SalonAgg.Service;

public class SalonService(ISalonRepository salonRepository) : ISalonService
{
    private Expression<Func<Salon, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(string name, long? id = null)
    {
        _predicate = x => x.Name == name;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (salonRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!salonRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
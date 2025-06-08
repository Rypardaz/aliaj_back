using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.WireScrewAgg.Service
{
    public class WireScrewService : IWireScrewService
    {
        private Expression<Func<WireScrew, bool>>? _predicate;
        private readonly IWireScrewRepository _wireScrewRepository;

        public WireScrewService(IWireScrewRepository wireScrewRepository)
        {
            _wireScrewRepository = wireScrewRepository;
        }

        public void ThrowWhenDuplicatedScrew(int screw, long? id = null)
        {
            _predicate = x => x.Screw == screw;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_wireScrewRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_wireScrewRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

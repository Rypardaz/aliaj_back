using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.PowderTypeGroupAgg.Service
{
    public class PowderTypeGroupService : IPowderTypeGroupService
    {
        private Expression<Func<PowderTypeGroup, bool>>? _predicate;
        private readonly IPowderTypeGroupRepository _powderTypeGroupRepository;

        public PowderTypeGroupService(IPowderTypeGroupRepository powderTypeGroupRepository)
        {
            _powderTypeGroupRepository = powderTypeGroupRepository;
        }

        public void ThrowWhenDuplicatedName(string name, long? id = null)
        {
            _predicate = x => x.Name == name;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_powderTypeGroupRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_powderTypeGroupRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;
using System.Linq.Expressions;

namespace Ex.Domain.PartGroupAgg.Service
{
    public class PartGroupService : IPartGroupService
    {
        private Expression<Func<PartGroup, bool>>? _predicate;
        private readonly IPartGroupRepository _partGroupRepository;

        public PartGroupService(IPartGroupRepository partGroupRepository)
        {
            _partGroupRepository = partGroupRepository;
        }

        public void ThrowWhenDuplicatedName(string name, long? id = null)
        {
            _predicate = x => x.Name == name;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_partGroupRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_partGroupRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

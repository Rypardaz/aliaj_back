using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.WireTypeGroupAgg.Service
{
    public class WireTypeGroupService : IWireTypeGroupService
    {
        private Expression<Func<WireTypeGroup, bool>>? _predicate;
        private readonly IWireTypeGroupRepository _wireTypeGroupRepository;

        public WireTypeGroupService(IWireTypeGroupRepository wireTypeGroupRepository)
        {
            _wireTypeGroupRepository = wireTypeGroupRepository;
        }

        public void ThrowWhenDuplicatedName(string name, long? id = null)
        {
            _predicate = x => x.Name == name;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_wireTypeGroupRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_wireTypeGroupRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

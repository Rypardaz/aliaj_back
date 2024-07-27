using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.WireTypeAgg.Service
{
    public class WireTypeService : IWireTypeService
    {
        private Expression<Func<WireType, bool>>? _predicate;
        private readonly IWireTypeRepository _wireTypeRepository;

        public WireTypeService(IWireTypeRepository wireTypeRepository)
        {
            _wireTypeRepository = wireTypeRepository;
        }

        public void ThrowWhenDuplicatedName(long wireTypeGroupId, string name, long? id = null)
        {
            _predicate = x => x.WireTypeGroupId == wireTypeGroupId;
            _predicate = _predicate.And(x => x.Name == name);


            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_wireTypeRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_wireTypeRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

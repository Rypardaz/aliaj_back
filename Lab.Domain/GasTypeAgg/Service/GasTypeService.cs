using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.GasTypeAgg.Service
{
    public class GasTypeService : IGasTypeService
    {
        private Expression<Func<GasType, bool>>? _predicate;
        private readonly IGasTypeRepository _gasTypeRepository;

        public GasTypeService(IGasTypeRepository gasTypeRepository)
        {
            _gasTypeRepository = gasTypeRepository;
        }

        public void ThrowWhenDuplicatedName(long gasTypeGroupId, string name, long? id = null)
        {
            _predicate = x => x.GasTypeGroupId == gasTypeGroupId;
            _predicate = _predicate.And(x => x.Name == name);

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_gasTypeRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_gasTypeRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

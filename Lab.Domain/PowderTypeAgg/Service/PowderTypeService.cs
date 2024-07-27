using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.PowderTypeAgg.Service
{
    public class PowderTypeService : IPowderTypeService
    {
        private Expression<Func<PowderType, bool>>? _predicate;
        private readonly IPowderTypeRepository _powderTypeRepository;

        public PowderTypeService(IPowderTypeRepository powderTypeRepository)
        {
            _powderTypeRepository = powderTypeRepository;
        }

        public void ThrowWhenDuplicatedName(long powderTypeGroupId, string name, long? id = null)
        {
            _predicate = x => x.PowderTypeGroupId == powderTypeGroupId;
            _predicate = _predicate.And(x => x.Name == name);

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_powderTypeRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_powderTypeRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

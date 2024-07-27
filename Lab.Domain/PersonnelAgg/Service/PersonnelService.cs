using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.PersonnelAgg.Service
{
    public class PersonnelService : IPersonnelService
    {
        private Expression<Func<Personnel, bool>>? _predicate;
        private readonly IPersonnelRepository _personnelRepository;

        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        public void ThrowWhenDuplicatedName(string name, string family, long? id = null)
        {
            _predicate = x => x.Name == name;
            _predicate = _predicate.And(x => x.Family == family);

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_personnelRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_personnelRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

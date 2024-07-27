using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.MachineAgg.Service
{
    public class MachineService : IMachineService
    {
        private Expression<Func<Machine, bool>>? _predicate;
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public void ThrowWhenDuplicatedCode(string code, long? id = null)
        {
            _predicate = x => x.Code == code;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_machineRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenDuplicatedName(string name, long? id = null)
        {
            _predicate = x => x.Name == name;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_machineRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_machineRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

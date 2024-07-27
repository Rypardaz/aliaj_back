using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.TaskMasterAgg.Service
{
    public class TaskMasterService : ITaskMasterService
    {
        private Expression<Func<TaskMaster, bool>>? _predicate;
        private readonly ITaskMasterRepository _taskMasterRepository;

        public TaskMasterService(ITaskMasterRepository taskMasterRepository)
        {
            _taskMasterRepository = taskMasterRepository;
        }

        public void ThrowWhenDuplicatedName(string name, long? id = null)
        {
            _predicate = x => x.Name == name;

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_taskMasterRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_taskMasterRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

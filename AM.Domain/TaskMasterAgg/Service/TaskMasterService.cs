using System.Linq.Expressions;
using AM.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Domain.Specification;

namespace AM.Domain.TaskMasterAgg.Service;

public class TaskMasterService(ITaskMasterRepository taskMasterRepository) : ITaskMasterService
{
    private Expression<Func<TaskMaster, bool>>? _predicate;

    public void ThrowWhenDuplicatedName(string name, long? id = null)
    {
        _predicate = x => x.Name == name;

        if (id is not null)
            _predicate = _predicate.And(x => x.Id != id);

        if (taskMasterRepository.Exists(_predicate))
            throw new DuplicatedDataEnteredException();
    }

    public void ThrowWhenRecordNotFound(long id)
    {
        _predicate = x => x.Id == id;
        if (!taskMasterRepository.Exists(_predicate))
            throw new RecordNotFoundException();
    }
}
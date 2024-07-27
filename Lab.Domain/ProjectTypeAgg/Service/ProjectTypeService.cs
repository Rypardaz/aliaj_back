using Ex.Domain.Share.Exception;
using PhoenixFramework.Core.Exceptions;
using System.Linq.Expressions;
using PhoenixFramework.Domain.Specification;

namespace Ex.Domain.ProjectTypeAgg.Service
{
    public class ProjectTypeService : IProjectTypeService
    {
        private Expression<Func<ProjectType, bool>>? _predicate;
        private readonly IProjectTypeRepository _projectTypeRepository;

        public ProjectTypeService(IProjectTypeRepository projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        public void ThrowWhenDuplicatedName(long salonId, string name, long? id = null)
        {
            _predicate = x => x.Name == name;
            _predicate = _predicate.And(x => x.SalonId == salonId);

            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (_projectTypeRepository.Exists(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public void ThrowWhenRecordNotFound(long id)
        {
            _predicate = x => x.Id == id;
            if (!_projectTypeRepository.Exists(_predicate))
                throw new RecordNotFoundException();
        }
    }
}

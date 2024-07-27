using Ex.Application.Contracts.ProjectType;
using Ex.Domain.ProjectTypeAgg.Service;
using Ex.Domain.ProjectTypeAgg;
using Ex.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace Ex.Application
{
    public class ProjectTypeCommandHandler :
        ICommandHandlerAsync<CreateProjectType, Guid>,
        ICommandHandlerAsync<EditProjectType>,
        ICommandHandler<RemoveProjectType>,
        ICommandHandler<ActivateProjectType>,
        ICommandHandler<DeactivateProjectType>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IProjectTypeRepository _projectTypeRepository;
        private readonly IProjectTypeService _projectTypeService;
        private readonly ISalonRepository _salonRepository;

        public ProjectTypeCommandHandler(IClaimHelper claimHelper, IProjectTypeRepository projectTypeRepository, IProjectTypeService projectTypeService, ISalonRepository salonRepository)
        {
            _claimHelper = claimHelper;
            _projectTypeRepository = projectTypeRepository;
            _projectTypeService = projectTypeService;
            _salonRepository = salonRepository;
        }

        public async Task<Guid> Handle(CreateProjectType command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var salonId = await _salonRepository.GetIdByAsync(command.SalonGuid);
            var projectType = new ProjectType(creator, command.Name, salonId, _projectTypeService);
            await _projectTypeRepository.CreateAsync(projectType);

            return projectType.Guid;
        }

        public async Task Handle(EditProjectType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var projectType = _projectTypeRepository.Load(command.Guid);
            var salonId = await _salonRepository.GetIdByAsync(command.SalonGuid);
            projectType.Edit(actor, command.Name, salonId, _projectTypeService);
        }

        public void Handle(RemoveProjectType command)
        {
            var projectType = _projectTypeRepository.Load(command.Guid);
            _projectTypeRepository.Delete(projectType);
        }
        public void Handle(ActivateProjectType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var projectType = _projectTypeRepository.Load(command.Guid);
            projectType.Activate();
        }

        public void Handle(DeactivateProjectType command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var projectType = _projectTypeRepository.Load(command.Guid);
            projectType.Deactivate();
        }
    }
}

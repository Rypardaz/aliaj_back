using Ex.Domain.ActivityAgg;
using PhoenixFramework.Identity;
using Ex.Domain.ActivityAgg.Service;
using Ex.Application.Contracts.Activity;
using PhoenixFramework.Application.Command;
using Ex.Domain.ListItemAgg;
using Ex.Domain.SalonAgg;

namespace Ex.Application
{
    public class ActivityCommandHandler :
        ICommandHandler<CreateActivity, Guid>,
        ICommandHandler<EditActivity>,
        ICommandHandler<RemoveActivity>,
        ICommandHandler<ActivateActivity>,
        ICommandHandler<DeactivateActivity>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityService _activityService;
        private readonly IListItemRepository _listItemRepository;
        private readonly ISalonRepository _salonRepository;

        public ActivityCommandHandler(IClaimHelper claimHelper
            , IActivityRepository activityRepository
            , IActivityService activityService,
            IListItemRepository listItemRepository, ISalonRepository salonRepository)
        {
            _claimHelper = claimHelper;
            _activityRepository = activityRepository;
            _activityService = activityService;
            _listItemRepository = listItemRepository;
            _salonRepository = salonRepository;
        }

        public Guid Handle(CreateActivity command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();

            int? sourceId = null;
            if (command.SourceGuid is not null)
                sourceId = _listItemRepository.GetIdBy(command.SourceGuid.Value);

            var salonIds = command.SalonGuids.Select(salonGuid => _salonRepository.GetIdBy(salonGuid)).ToList();

            var activity = new Activity(creator, command.Code, command.Name, command.Type, command.SubType, sourceId,
                command.IsOther, command.WithOutPersonnel, command.WithOutProject, salonIds, _activityService);
            
            _activityRepository.Create(activity);
            
            return activity.Guid;
        }

        public void Handle(EditActivity command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var activity = _activityRepository.Load(command.Guid, "Salons");

            int? sourceId = null;
            if (command.SourceGuid is not null)
                sourceId = _listItemRepository.GetIdBy(command.SourceGuid.Value);

            var salonIds = command.SalonGuids.Select(salonGuid => _salonRepository.GetIdBy(salonGuid)).ToList();
            activity.Edit(actor, command.Code, command.Name, command.Type, command.SubType, sourceId, command.IsOther,
                command.WithOutPersonnel, command.WithOutProject, salonIds, _activityService);
        }

        public void Handle(RemoveActivity command)
        {
            var activity = _activityRepository.Load(command.Guid);
            _activityRepository.Delete(activity);
        }

        public void Handle(ActivateActivity command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var activity = _activityRepository.Load(command.Guid);
            activity.Activate();
        }

        public void Handle(DeactivateActivity command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var activity = _activityRepository.Load(command.Guid);
            activity.Deactivate();
        }
    }
}
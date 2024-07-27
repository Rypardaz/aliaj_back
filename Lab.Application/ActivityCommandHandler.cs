using Ex.Domain.ActivityAgg;
using PhoenixFramework.Identity;
using Ex.Domain.ActivityAgg.Service;
using Ex.Application.Contracts.Activity;
using PhoenixFramework.Application.Command;
using Ex.Domain.ListItemAgg;

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

        public ActivityCommandHandler(IClaimHelper claimHelper
            , IActivityRepository activityRepository
            , IActivityService activityService,
            IListItemRepository listItemRepository)
        {
            _claimHelper = claimHelper;
            _activityRepository = activityRepository;
            _activityService = activityService;
            _listItemRepository = listItemRepository;
        }

        public Guid Handle(CreateActivity command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();

            int? sourceId = null;
            if (command.SourceGuid is not null)
                sourceId = _listItemRepository.GetIdBy(command.SourceGuid.Value);

            var activity = new Activity(creator, command.Name, command.Type, command.SubType, sourceId, command.IsOther, _activityService);
            _activityRepository.Create(activity);
            return activity.Guid;
        }

        public void Handle(EditActivity command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var activity = _activityRepository.Load(command.Guid);
            
            int? sourceId = null;
            if (command.SourceGuid is not null)
                sourceId = _listItemRepository.GetIdBy(command.SourceGuid.Value);
            
            activity.Edit(actor, command.Name, command.Type, command.SubType, sourceId, command.IsOther, _activityService);
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

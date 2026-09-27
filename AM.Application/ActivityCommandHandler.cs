using AM.Application.Contracts.Activity;
using AM.Domain.ActivityAgg;
using AM.Domain.ActivityAgg.Service;
using AM.Domain.ListItemAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Identity;

namespace AM.Application;

public class ActivityCommandHandler(
    IClaimHelper claimHelper,
    IActivityRepository activityRepository,
    IActivityService activityService,
    IListItemRepository listItemRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateActivity, Guid>,
        ICommandHandler<EditActivity>,
        ICommandHandler<RemoveActivity>,
        ICommandHandler<ActivateActivity>,
        ICommandHandler<DeactivateActivity>
{
    public Guid Handle(CreateActivity command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        int? sourceId = null;
        if (command.SourceGuid is not null)
            sourceId = listItemRepository.GetIdBy(command.SourceGuid.Value);

        var salonIds = command.SalonGuids.Select(salonGuid => salonRepository.GetIdBy(salonGuid)).ToList();

        var activity = new Activity(creator, command.Code, command.Name, command.Type, command.SubType, sourceId,
            command.IsOther, command.WithOutPersonnel, command.WithOutProject, salonIds, activityService);
            
        activityRepository.Create(activity);
            
        return activity.Guid;
    }

    public void Handle(EditActivity command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var activity = activityRepository.Load(command.Guid, "Salons");

        int? sourceId = null;
        if (command.SourceGuid is not null)
            sourceId = listItemRepository.GetIdBy(command.SourceGuid.Value);

        var salonIds = command.SalonGuids.Select(salonGuid => salonRepository.GetIdBy(salonGuid)).ToList();
        activity.Edit(actor, command.Code, command.Name, command.Type, command.SubType, sourceId, command.IsOther,
            command.WithOutPersonnel, command.WithOutProject, salonIds, activityService);
    }

    public void Handle(RemoveActivity command)
    {
        var activity = activityRepository.Load(command.Guid);
        activityRepository.Delete(activity);
    }

    public void Handle(ActivateActivity command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var activity = activityRepository.Load(command.Guid);
        activity.Activate();
    }

    public void Handle(DeactivateActivity command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var activity = activityRepository.Load(command.Guid);
        activity.Deactivate();
    }
}
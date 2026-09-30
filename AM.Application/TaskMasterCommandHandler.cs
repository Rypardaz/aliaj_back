using AM.Domain.TaskMasterAgg;
using PhoenixFramework.Identity;
using AM.Domain.TaskMasterAgg.Service;
using AM.Application.Contracts.TaskMaster;
using PhoenixFramework.Application.Command;

namespace AM.Application;

public class TaskMasterCommandHandler(
    IClaimHelper claimHelper,
    ITaskMasterRepository taskMasterRepository,
    ITaskMasterService taskMasterService) :
    ICommandHandler<CreateTaskMaster, Guid>,
    ICommandHandler<EditTaskMaster>,
    ICommandHandler<RemoveTaskMaster>,
    ICommandHandler<ActivateTaskMaster>,
    ICommandHandler<DeactivateTaskMaster>
{
    public Guid Handle(CreateTaskMaster command)
    {
        var creator = claimHelper.GetCurrentUserGuid();

        var contacts = command.Contacts
            .Select(x => new TaskMasterContact(x.TaskMasterId, x.Name, x.Post, x.Phone, x.CellPhone))
            .ToList();

        var taskMaster = new TaskMaster(creator, command.Name, command.IndustryTypeId, command.RegistNo,
            command.NationalCode, command.EconomicCode, command.OfficeProvinceId, command.OfficeCityId,
            command.OfficeZipCode, command.OfficeAddress, command.OfficePhone, command.FactoryProvinceId,
            command.FactoryCityId, command.FactoryZipCode, command.FactoryAddress, command.FactoryPhone, contacts,
            taskMasterService);

        taskMasterRepository.Create(taskMaster);
        return taskMaster.Guid;
    }

    public void Handle(EditTaskMaster command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var taskMaster = taskMasterRepository.Load(command.Guid);

        var contacts = command.Contacts
            .Select(x => new TaskMasterContact(x.TaskMasterId, x.Name, x.Post, x.Phone, x.CellPhone))
            .ToList();

        taskMaster.Edit(actor, command.Name, command.IndustryTypeId, command.RegistNo,
            command.NationalCode, command.EconomicCode, command.OfficeProvinceId, command.OfficeCityId,
            command.OfficeZipCode, command.OfficeAddress, command.OfficePhone, command.FactoryProvinceId,
            command.FactoryCityId, command.FactoryZipCode, command.FactoryAddress, command.FactoryPhone, contacts,
            taskMasterService);
    }

    public void Handle(RemoveTaskMaster command)
    {
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMasterRepository.Delete(taskMaster);
    }

    public void Handle(ActivateTaskMaster command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMaster.Activate();
    }

    public void Handle(DeactivateTaskMaster command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var taskMaster = taskMasterRepository.Load(command.Guid);
        taskMaster.Deactivate();
    }
}
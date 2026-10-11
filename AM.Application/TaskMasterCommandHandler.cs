using AM.Domain.RegionAgg;
using AM.Domain.TaskMasterAgg;
using PhoenixFramework.Identity;
using AM.Domain.TaskMasterAgg.Service;
using AM.Application.Contracts.TaskMaster;
using PhoenixFramework.Application.Command;

namespace AM.Application;

public class TaskMasterCommandHandler(
    IClaimHelper claimHelper,
    IRegionRepository regionRepository,
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

        int? officeProvinceId = null;
        if (command.OfficeProvinceGuid is not null)
            officeProvinceId = regionRepository.GetIdBy(command.OfficeProvinceGuid.Value);

        int? officeCityId = null;
        if (command.OfficeCityGuid is not null)
            officeCityId = regionRepository.GetIdBy(command.OfficeCityGuid.Value);

        int? factoryProvinceId = null;
        if (command.FactoryProvinceGuid is not null)
            factoryProvinceId = regionRepository.GetIdBy(command.FactoryProvinceGuid.Value);

        int? factoryCityId = null;
        if (command.FactoryCityGuid is not null)
            factoryCityId = regionRepository.GetIdBy(command.FactoryCityGuid.Value);

        var taskMaster = new TaskMaster(creator, command.Name, command.IndustryTypeId, command.RegistNo,
            command.NationalCode, command.EconomicCode, officeProvinceId, officeCityId, command.OfficeZipCode,
            command.OfficeAddress, command.OfficePhone, factoryProvinceId, factoryCityId, command.FactoryZipCode,
            command.FactoryAddress, command.FactoryPhone, contacts, taskMasterService);

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

        int? officeProvinceId = null;
        if (command.OfficeProvinceGuid is not null)
            officeProvinceId = regionRepository.GetIdBy(command.OfficeProvinceGuid.Value);

        int? officeCityId = null;
        if (command.OfficeCityGuid is not null)
            officeCityId = regionRepository.GetIdBy(command.OfficeCityGuid.Value);

        int? factoryProvinceId = null;
        if (command.FactoryProvinceGuid is not null)
            factoryProvinceId = regionRepository.GetIdBy(command.FactoryProvinceGuid.Value);

        int? factoryCityId = null;
        if (command.FactoryCityGuid is not null)
            factoryCityId = regionRepository.GetIdBy(command.FactoryCityGuid.Value);

        taskMaster.Edit(actor, command.Name, command.IndustryTypeId, command.RegistNo, command.NationalCode,
            command.EconomicCode, officeProvinceId, officeCityId, command.OfficeZipCode, command.OfficeAddress,
            command.OfficePhone, factoryProvinceId, factoryCityId, command.FactoryZipCode, command.FactoryAddress,
            command.FactoryPhone, contacts, taskMasterService);
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
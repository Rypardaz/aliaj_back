using Ex.Domain.DailyRecordAgg;
using PhoenixFramework.Identity;
using Ex.Application.Contracts.DailyRecord;
using PhoenixFramework.Application.Command;
using Ex.Domain.DailyRecordAgg.Service;
using Ex.Domain.SalonAgg;
using Ex.Domain.MachineAgg;
using Ex.Domain.ListItemAgg;
using Ex.Domain.TaskMasterAgg;
using PhoenixFramework.Core.Exceptions;
using System.ComponentModel;

namespace Ex.Application;

public class DailyRecordCommandHandler(
    IClaimHelper claimHelper,
    IDailyRecordRepository dailyRecordRepository,
    IDailyRecordService dailyRecordService,
    IListItemRepository listItemRepository,
    IMachineRepository machineRepository,
    ISalonRepository salonRepository)
    :
        ICommandHandler<CreateDailyRecord, Guid>,
        ICommandHandler<EditDailyRecord>,
        ICommandHandler<RemoveDailyRecord>
{
    public Guid Handle(CreateDailyRecord command)
    {
        var creator = claimHelper.GetCurrentUserGuid();
        var shiftId = listItemRepository.GetIdBy(command.ShiftGuid);
        var machineId = machineRepository.GetIdBy(command.MachineGuid);
        var salonId = salonRepository.GetIdBy(command.SalonGuid);

        if (dailyRecordRepository.Exists(x =>
                x.Date == command.Date &&
                x.ShiftId == shiftId &&
                x.MachineId == machineId &&
                x.Head == command.Head))
            throw new DuplicatedDataEnteredException();

        var dailyRecord = new DailyRecord(creator, salonId, command.Date, shiftId, machineId, command.Head,
            command.Description, command.TotalHours, command.TotalActivityHours, command.TotalWeldingActivityHours,
            command.TotalNonWeldingActivityHours, command.TotalStopHours, command.TotalProductionStopHours,
            command.TotalNonProductionStopHours, command.TotalWireConsumption, dailyRecordService);

        dailyRecordService.SetDetails(dailyRecord, command.Details);

        dailyRecordRepository.Create(dailyRecord);
        return dailyRecord.Guid;
    }

    public void Handle(EditDailyRecord command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var dailyRecord = dailyRecordRepository.Load(command.Guid, "Details");

        var shiftId = listItemRepository.GetIdBy(command.ShiftGuid);
        var machineId = machineRepository.GetIdBy(command.MachineGuid);

        if (dailyRecordRepository.Exists(x =>
                x.Date == command.Date && x.ShiftId == shiftId && x.MachineId == machineId &&
                x.Guid != command.Guid && x.Head == command.Head))
            throw new DuplicatedDataEnteredException();

        dailyRecord.Edit(actor, command.Date, shiftId, machineId, command.Head, command.Description,
            command.TotalHours, command.TotalActivityHours, command.TotalWeldingActivityHours,
            command.TotalNonWeldingActivityHours, command.TotalStopHours, command.TotalProductionStopHours,
            command.TotalNonProductionStopHours, command.TotalWireConsumption, dailyRecordService);

        dailyRecordService.SetDetails(dailyRecord, command.Details);
    }

    public void Handle(RemoveDailyRecord command)
    {
        var actor = claimHelper.GetCurrentUserGuid();
        var dailyRecord = dailyRecordRepository.Load(command.Guid);
        dailyRecordRepository.Delete(dailyRecord);
    }
}
using AM.Application.Contracts.DailyRecord;
using AM.Domain.DailyRecordAgg;
using AM.Domain.DailyRecordAgg.Service;
using AM.Domain.ListItemAgg;
using AM.Domain.MachineAgg;
using AM.Domain.SalonAgg;
using PhoenixFramework.Application.Command;
using PhoenixFramework.Core.Exceptions;
using PhoenixFramework.Identity;

namespace AM.Application;

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
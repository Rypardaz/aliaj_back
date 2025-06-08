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

namespace Ex.Application
{
    public class DailyRecordCommandHandler :
        ICommandHandler<CreateDailyRecord, Guid>,
        ICommandHandler<EditDailyRecord>,
        ICommandHandler<RemoveDailyRecord>
    {
        private readonly IClaimHelper _claimHelper;
        private readonly IDailyRecordRepository _dailyRecordRepository;
        private readonly IDailyRecordService _dailyRecordService;
        private readonly IListItemRepository _listItemRepository;
        private readonly IMachineRepository _machineRepository;
        private readonly ISalonRepository _salonRepository;

        public DailyRecordCommandHandler(IClaimHelper claimHelper, IDailyRecordRepository dailyRecordRepository,
            IDailyRecordService dailyRecordService, IListItemRepository listItemRepository,
            IMachineRepository machineRepository, ISalonRepository salonRepository)
        {
            _claimHelper = claimHelper;
            _dailyRecordRepository = dailyRecordRepository;
            _dailyRecordService = dailyRecordService;
            _listItemRepository = listItemRepository;
            _machineRepository = machineRepository;
            _salonRepository = salonRepository;
        }

        public Guid Handle(CreateDailyRecord command)
        {
            var creator = _claimHelper.GetCurrentUserGuid();
            var shiftId = _listItemRepository.GetIdBy(command.ShiftGuid);
            var machineId = _machineRepository.GetIdBy(command.MachineGuid);
            var salonId = _salonRepository.GetIdBy(command.SalonGuid);

            if (_dailyRecordRepository.Exists(x =>
                    x.Date == command.Date &&
                    x.ShiftId == shiftId &&
                    x.MachineId == machineId &&
                    x.Head == command.Head))
                throw new DuplicatedDataEnteredException();

            var dailyRecord = new DailyRecord(creator, salonId, command.Date, shiftId, machineId, command.Head,
                command.Description, command.TotalHours, command.TotalActivityHours, command.TotalWeldingActivityHours,
                command.TotalNonWeldingActivityHours, command.TotalStopHours, command.TotalProductionStopHours,
                command.TotalNonProductionStopHours, command.TotalWireConsumption, _dailyRecordService);

            _dailyRecordService.SetDetails(dailyRecord, command.Details);

            _dailyRecordRepository.Create(dailyRecord);
            return dailyRecord.Guid;
        }

        public void Handle(EditDailyRecord command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var dailyRecord = _dailyRecordRepository.Load(command.Guid, "Details");

            var shiftId = _listItemRepository.GetIdBy(command.ShiftGuid);
            var machineId = _machineRepository.GetIdBy(command.MachineGuid);

            if (_dailyRecordRepository.Exists(x =>
                    x.Date == command.Date && x.ShiftId == shiftId && x.MachineId == machineId &&
                    x.Guid != command.Guid && x.Head == command.Head))
                throw new DuplicatedDataEnteredException();

            dailyRecord.Edit(actor, command.Date, shiftId, machineId, command.Head, command.Description,
                command.TotalHours, command.TotalActivityHours, command.TotalWeldingActivityHours,
                command.TotalNonWeldingActivityHours, command.TotalStopHours, command.TotalProductionStopHours,
                command.TotalNonProductionStopHours, command.TotalWireConsumption, _dailyRecordService);

            _dailyRecordService.SetDetails(dailyRecord, command.Details);
        }

        public void Handle(RemoveDailyRecord command)
        {
            var actor = _claimHelper.GetCurrentUserGuid();
            var dailyRecord = _dailyRecordRepository.Load(command.Guid);
            _dailyRecordRepository.Delete(dailyRecord);
        }
    }
}
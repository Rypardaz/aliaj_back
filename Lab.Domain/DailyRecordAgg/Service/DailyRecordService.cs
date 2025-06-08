using Ex.Domain.GasTypeAgg;
using Ex.Domain.ProjectAgg;
using Ex.Domain.ActivityAgg;
using Ex.Domain.PersonnelAgg;
using Ex.Domain.PowderTypeAgg;
using Ex.Application.Contracts.DailyRecord;
using Ex.Domain.WireTypeAgg;
using Ex.Domain.WireScrewAgg;
using PhoenixFramework.Core;
using PhoenixFramework.Core.Exceptions;
using Ex.Domain.WorkCalendarAgg;
using System.Numerics;

namespace Ex.Domain.DailyRecordAgg.Service;

public class DailyRecordService : IDailyRecordService
{
    private readonly IPersonnelRepository _personnelRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IActivityRepository _activityRepository;
    private readonly IGasTypeRepository _gasTypeRepository;
    private readonly IPowderTypeRepository _powderTypeRepository;
    private readonly IWireTypeRepository _wireTypeRepository;
    private readonly IWireScrewRepository _wireScrewRepository;
    private readonly IWorkCalendarRepository _workCalendarRepository;

    public DailyRecordService(IPersonnelRepository personnelRepository, IProjectRepository projectRepository,
        IActivityRepository activityRepository, IGasTypeRepository gasTypeRepository,
        IPowderTypeRepository powderTypeRepository, IWireTypeRepository wireTypeRepository,
        IWireScrewRepository wireScrewRepository, IWorkCalendarRepository workCalendarRepository)
    {
        _personnelRepository = personnelRepository;
        _projectRepository = projectRepository;
        _activityRepository = activityRepository;
        _gasTypeRepository = gasTypeRepository;
        _powderTypeRepository = powderTypeRepository;
        _wireTypeRepository = wireTypeRepository;
        _wireScrewRepository = wireScrewRepository;
        _workCalendarRepository = workCalendarRepository;
    }

    public void SetDetails(DailyRecord dailyRecord, List<DailyRecordDetailOperations> details)
    {
        dailyRecord.EmptyDetails();

        foreach (var detail in details)
        {
            var personnelId = _personnelRepository.GetIdBy(detail.PersonnelGuid);
           
            long? projectDetailId = null;
            if (detail.ProjectDetailGuid is not null)
                projectDetailId = _projectRepository.DetailIdBy(detail.ProjectDetailGuid.Value);

            var activityId = _activityRepository.GetIdBy(detail.ActivityGuid);

            var item = new DailyRecordDetail(dailyRecord.Id, personnelId, projectDetailId, detail.StartTime,
                detail.EndTime, activityId, detail.WireConsumption, detail.ProducedScrew, detail.ProducedWire);

            if (detail.GasTypeGuid is not null)
                item.SetGasTypeId(_gasTypeRepository.GetIdBy(detail.GasTypeGuid.Value));

            if (detail.PowderTypeGuid is not null)
                item.SetPowderTypeId(_powderTypeRepository.GetIdBy(detail.PowderTypeGuid.Value));

            if (detail.WireTypeGuid is not null)
                item.SetWireTypeId(_wireTypeRepository.GetIdBy(detail.WireTypeGuid.Value));

            if (detail.ProducedWireTypeGuid is not null)
                item.SetProducedWireTypeId(_wireTypeRepository.GetIdBy(detail.ProducedWireTypeGuid.Value));

            if (detail.WireScrewGuid is not null)
            {
                var wireScrew = _wireScrewRepository.Load(detail.WireScrewGuid.Value);
                // TODO: Check Wire Screw Remained In Stock;
                item.SetWireScrewId(wireScrew.Id);
            }

            dailyRecord.AddDetail(item);
        }

        var totalMinute = 0;

        foreach (var item in dailyRecord.Details)
        {
            var startHour = int.Parse(item.StartTime.Substring(0, 2));
            var startMinute = int.Parse(item.StartTime.Substring(2, 2));

            var endHour = int.Parse(item.EndTime.Substring(0, 2));
            var endMinute = int.Parse(item.EndTime.Substring(2, 2));

            var hours = endHour - startHour;
            if (hours < 0)
                hours += 24;

            var minutes = endMinute - startMinute;
            if (minutes < 0)
            {
                minutes += 60;
                hours -= 1;
            }

            totalMinute += (hours * 60) + minutes;
        }

        var shift = _workCalendarRepository.GetBy(dailyRecord.Date, dailyRecord.ShiftId, dailyRecord.SalonId);

        if (totalMinute > shift.WorkTime * 60)
            throw new BusinessException("0", "مجموع ساعت فرم بیشتر از حد مجاز تعریف شده در ساعات کاری است.");
        if (totalMinute < shift.WorkTime * 60)
            throw new BusinessException("0", "مجموع ساعت فرم کمتر از حد مجاز تعریف شده در ساعات کاری است.");

        if (int.Parse(dailyRecord.Details.First().StartTime) < int.Parse(shift.StartTime))
            throw new BusinessException("0", "ساعات وارد شده قبل از ساعت شروع شیفت کاری است.");

        if (int.Parse(dailyRecord.Details.Last().EndTime) > int.Parse(shift.EndTime))
            throw new BusinessException("0", "ساعات وارد شده بعد از ساعت پایان شیفت کاری است.");
    }
}
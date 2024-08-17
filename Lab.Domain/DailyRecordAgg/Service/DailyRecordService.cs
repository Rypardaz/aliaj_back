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
            var projectDetailId = _projectRepository.DetailIdBy(detail.ProjectDetailGuid);
            var activityId = _activityRepository.GetIdBy(detail.ActivityGuid);

            var item = new DailyRecordDetail(dailyRecord.Id, personnelId, projectDetailId, detail.StartTime,
                detail.EndTime, activityId, detail.WireConsumption);

            if (detail.GasTypeGuid is not null)
                item.SetGasTypeId(_gasTypeRepository.GetIdBy(detail.GasTypeGuid.Value));

            if (detail.PowderTypeGuid is not null)
                item.SetPowderTypeId(_powderTypeRepository.GetIdBy(detail.PowderTypeGuid.Value));

            if (detail.WireTypeGuid is not null)
                item.SetWireTypeId(_wireTypeRepository.GetIdBy(detail.WireTypeGuid.Value));

            if (detail.WireScrewGuid is not null)
                item.SetWireScrewId(_wireScrewRepository.GetIdBy(detail.WireScrewGuid.Value));

            dailyRecord.AddDetail(item);
        }

        foreach (var (item, index) in dailyRecord.Details.WithIndex())
        {
            if (index == 0) continue;

            var prevItem = dailyRecord.Details[index - 1];

            var prevEndTime = int.Parse(prevItem.EndTime.Replace(":", ""));
            var startTime = int.Parse(item.StartTime.Replace(":", ""));

            if (prevEndTime > startTime)
                throw new BusinessException("0", "ساعت شروع ردیف جدید نباید زودتر از پایان ردیف قبلی باشد.");
        }

        var totalHours = 0.0;

        foreach (var item in dailyRecord.Details)
        {
            var startHour = double.Parse(item.StartTime.Substring(0, 2));
            var startMinute = double.Parse(item.StartTime.Substring(2, 2));

            var endHour = double.Parse(item.EndTime.Substring(0, 2));
            var endMinute = double.Parse(item.EndTime.Substring(2, 2));

            var hours = endHour - startHour;
            if (hours < 0)
                hours += 24;

            var minutes = endMinute - startMinute;
            if (minutes < 0) minutes += 60;

            totalHours += hours + (minutes / 60);
        }

        var shift = _workCalendarRepository.GetBy(dailyRecord.Date, dailyRecord.ShiftId);

        if (totalHours > shift.WorkTime)
            throw new BusinessException("0", "مجموع ساعت فرم بیشتر از حد مجاز تعریف شده در ساعات کاری است.");
        if (totalHours < shift.WorkTime)
            throw new BusinessException("0", "مجموع ساعت فرم کمتر از حد مجاز تعریف شده در ساعات کاری است.");

        if (dailyRecord.Details.Any(x => int.Parse(x.StartTime) < int.Parse(shift.StartTime)))
            throw new BusinessException("0", "ساعات وارد شده قبل از ساعت شروع شیفت کاری است.");

        if (dailyRecord.Details.Any(x => int.Parse(x.EndTime) > int.Parse(shift.EndTime)))
            throw new BusinessException("0", "ساعات وارد شده بعد از ساعت پایان شیفت کاری است.");
    }
}
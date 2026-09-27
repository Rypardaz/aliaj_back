using AM.Application.Contracts.DailyRecord;
using AM.Domain.ActivityAgg;
using AM.Domain.GasTypeAgg;
using AM.Domain.PersonnelAgg;
using AM.Domain.PowderTypeAgg;
using AM.Domain.ProjectAgg;
using AM.Domain.WireScrewAgg;
using AM.Domain.WireTypeAgg;
using AM.Domain.WorkCalendarAgg;
using PhoenixFramework.Core.Exceptions;

namespace AM.Domain.DailyRecordAgg.Service;

public class DailyRecordService(
    IPersonnelRepository personnelRepository,
    IProjectRepository projectRepository,
    IActivityRepository activityRepository,
    IGasTypeRepository gasTypeRepository,
    IPowderTypeRepository powderTypeRepository,
    IWireTypeRepository wireTypeRepository,
    IWireScrewRepository wireScrewRepository,
    IWorkCalendarRepository workCalendarRepository)
    : IDailyRecordService
{
    public void SetDetails(DailyRecord dailyRecord, List<DailyRecordDetailOperations> details)
    {
        dailyRecord.EmptyDetails();

        foreach (var detail in details)
        {
            var personnelId = personnelRepository.GetIdBy(detail.PersonnelGuid);
           
            long? projectDetailId = null;
            if (detail.ProjectDetailGuid is not null)
                projectDetailId = projectRepository.DetailIdBy(detail.ProjectDetailGuid.Value);

            var activityId = activityRepository.GetIdBy(detail.ActivityGuid);

            var item = new DailyRecordDetail(dailyRecord.Id, personnelId, projectDetailId, detail.StartTime,
                detail.EndTime, activityId, detail.WireConsumption, detail.ProducedScrew, detail.ProducedWire);

            if (detail.GasTypeGuid is not null)
                item.SetGasTypeId(gasTypeRepository.GetIdBy(detail.GasTypeGuid.Value));

            if (detail.PowderTypeGuid is not null)
                item.SetPowderTypeId(powderTypeRepository.GetIdBy(detail.PowderTypeGuid.Value));

            if (detail.WireTypeGuid is not null)
                item.SetWireTypeId(wireTypeRepository.GetIdBy(detail.WireTypeGuid.Value));

            if (detail.ProducedWireTypeGuid is not null)
                item.SetProducedWireTypeId(wireTypeRepository.GetIdBy(detail.ProducedWireTypeGuid.Value));

            if (detail.WireScrewGuid is not null)
            {
                var wireScrew = wireScrewRepository.Load(detail.WireScrewGuid.Value);
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

        var shift = workCalendarRepository.GetBy(dailyRecord.Date, dailyRecord.ShiftId, dailyRecord.SalonId);

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
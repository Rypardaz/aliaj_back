using Ex.Domain.WorkCalendarAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository;

public class WorkCalendarRepository(AliajCommandContext context)
    : BaseRepository<int, WorkCalendar>(context), IWorkCalendarRepository
{
    public WorkCalendar GetBy(string date, int shiftId, long salonId)
    {
        return context.WorkCalendar
            .Where(x => x.SalonId == salonId)
            .Where(x => x.Date == date)
            .First(x => x.ShiftId == shiftId);
    }
}
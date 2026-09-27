using PhoenixFramework.Domain;

namespace AM.Domain.WorkCalendarAgg;

public interface IWorkCalendarRepository : IRepository<int, WorkCalendar>
{
    WorkCalendar GetBy(string date, int shiftId, long salonId);
}
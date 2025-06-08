using PhoenixFramework.Domain;

namespace Ex.Domain.WorkCalendarAgg
{
    public interface IWorkCalendarRepository : IRepository<int, WorkCalendar>
    {
        WorkCalendar GetBy(string date, int shiftId, long salonId);
    }
}

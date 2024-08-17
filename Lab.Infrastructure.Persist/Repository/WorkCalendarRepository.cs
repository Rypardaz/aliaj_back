using Ex.Domain.WorkCalendarAgg;
using Microsoft.EntityFrameworkCore;
using PhoenixFramework.EntityFramework;

namespace Lab.Infrastructure.Persist.Repository
{
    public class WorkCalendarRepository : BaseRepository<int, WorkCalendar>, IWorkCalendarRepository
    {
        private readonly LaboratoryCommandContext _context;

        public WorkCalendarRepository(LaboratoryCommandContext context) : base(context)
        {
            this._context = context;
        }

        public WorkCalendar GetBy(string date, int shiftId)
        {
            return _context.WorkCalendar
                .Where(x => x.Date == date)
                .Where(x => x.ShiftId == shiftId)
                .First();
        }
    }
}

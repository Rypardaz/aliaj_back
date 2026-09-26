using Ex.Domain.SalonAgg;

namespace Ex.Domain.ActivityAgg;

public class ActivitySalon
{
    public long Id { get; set; }
    public long ActivityId { get; set; }
    public Activity Activity { get; set; }
    public long SalonId { get; set; }
    public Salon Salon { get; set; }
}
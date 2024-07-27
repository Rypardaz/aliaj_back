using Ex.Domain.DailyRecordAgg.Service;
using PhoenixFramework.Domain;

namespace Ex.Domain.DailyRecordAgg
{
    public class DailyRecord : AuditableAggregateRootBase<long>
    {
        public long SalonId { get; private set; }
        public string Date { get; private set; }
        public int ShiftId { get; private set; }
        public long MachineId { get; private set; }
        public byte Head { get; private set; }
        public string? Description { get; private set; }

        public decimal TotalHours { get; private set; }
        public decimal TotalActivityHours { get; private set; }
        public decimal TotalWeldingActivityHours { get; private set; }
        public decimal TotalNonWeldingActivityHours { get; private set; }
        public decimal TotalStopHours { get; private set; }
        public decimal TotalProductionStopHours { get; private set; }
        public decimal TotalNonProductionStopHours { get; private set; }
        public decimal TotalWireConsumption { get; private set; }

        public List<DailyRecordDetail> Details { get; private set; }

        protected DailyRecord()
        {
        }

        public DailyRecord(Guid creator, long salonId, string date, int shiftId, long machineId, byte head,
            string? description, decimal totalHours, decimal totalActivityHours, decimal totalWeldingActivityHours,
            decimal totalNonWeldingActivityHours, decimal totalStopHours, decimal totalProductionStopHours,
            decimal totalNonProductionStopHours, decimal totalWireConsumption, IDailyRecordService service) : base(creator)
        {
            SalonId = salonId;
            Date = date;
            ShiftId = shiftId;
            MachineId = machineId;
            Head = head;
            Description = description;

            TotalHours = totalHours;
            TotalActivityHours = totalActivityHours;
            TotalWeldingActivityHours = totalWeldingActivityHours;
            TotalNonWeldingActivityHours = totalNonWeldingActivityHours;
            TotalStopHours = totalStopHours;
            TotalProductionStopHours = totalProductionStopHours;
            TotalNonProductionStopHours = totalNonProductionStopHours;
            TotalWireConsumption = totalWireConsumption;
        }

        public void Edit(Guid actor, string date, int shiftId, long machineId, byte head, string? description,
            decimal totalHours, decimal totalActivityHours, decimal totalWeldingActivityHours, decimal totalNonWeldingActivityHours,
            decimal totalStopHours, decimal totalProductionStopHours, decimal totalNonProductionStopHours,
            decimal totalWireConsumption, IDailyRecordService service)
        {
            Date = date;
            ShiftId = shiftId;
            MachineId = machineId;
            Head = head;
            Description = description;

            TotalHours = totalHours;
            TotalActivityHours = totalActivityHours;
            TotalWeldingActivityHours = totalWeldingActivityHours;
            TotalNonWeldingActivityHours = totalNonWeldingActivityHours;
            TotalStopHours = totalStopHours;
            TotalProductionStopHours = totalProductionStopHours;
            TotalNonProductionStopHours = totalNonProductionStopHours;
            TotalWireConsumption = totalWireConsumption;

            Modified(actor);
        }

        public void EmptyDetails()
        {
            Details = new List<DailyRecordDetail>();
        }

        public void AddDetail(DailyRecordDetail detail)
        {
            Details.Add(detail);
        }
    }
}
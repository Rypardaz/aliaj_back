using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.DailyRecord
{
    public class CreateDailyRecord : ICommand
    {
        public string Date { get; set; }
        public Guid SalonGuid { get; set; }
        public Guid ShiftGuid { get; set; }
        public Guid MachineGuid { get; set; }
        public byte Head { get; set; }
        public string? Description { get; set; }
        public decimal TotalHours { get; set; }
        public decimal TotalActivityHours { get; set; }
        public decimal TotalWeldingActivityHours { get; set; }
        public decimal TotalNonWeldingActivityHours { get; set; }
        public decimal TotalStopHours { get; set; }
        public decimal TotalProductionStopHours { get; set; }
        public decimal TotalNonProductionStopHours { get; set; }
        public decimal TotalWireConsumption { get; set; }
        public List<DailyRecordDetailOperations> Details { get; set; }
    }
}

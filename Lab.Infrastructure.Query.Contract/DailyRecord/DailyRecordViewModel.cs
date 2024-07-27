using Ex.Application.Contracts.DailyRecord;
using PhoenixFramework.Company.Query;

namespace Lab.Infrastructure.Query.Contracts.DailyRecord
{
    public class DailyRecordViewModel : ViewModelAbilities
    {
        public string Date { get; set; }
        public string ShiftName { get; set; }
        public string MachineName { get; set; }
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
        public List<DailyRecordDetailOperations> Detials { get; set; }
    }
}

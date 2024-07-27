﻿namespace Lab.Infrastructure.Report.Contract.WireTypeConsumption
{
    public class WireTypeConsumptionReportSearchModel
    {
        public Guid SalonGuid { get; set; }
        public Guid? ShiftGuid { get; set; }
        public int Type { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}

namespace Lab.Infrastructure.Report.Contract.Chart;

public class ChartViewModel
{
    public string Title { get; set; }
    public long ShiftTitle { get; set; }
    public long WireConsumption { get; set; }
    public long WeldingTime { get; set; }
    public long StandardWireConsumption { get; set; }
    public long Randeman { get; set; }

    public string X { get; set; }
    public string Y { get; set; }
}
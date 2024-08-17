namespace Lab.Infrastructure.Report.Contract.Chart
{
    public interface IChartReportService
    {
        List<ChartViewModel> GetWireConsumptionChart(ChartSearchModel searchModel);
        List<ChartViewModel> GetRandemanChart(ChartSearchModel searchModel);
        List<ChartViewModel> GetWireConsumptionToStandardChart(ChartSearchModel searchModel);
        List<ChartViewModel> GetProjectChart(ChartSearchModel searchModel);
    }
}
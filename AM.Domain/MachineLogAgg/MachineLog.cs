using PhoenixFramework.Domain;

namespace AM.Domain.MachineLogAgg;

public class MachineLog(
    long machineId,
    DateTime time,
    double v1,
    double i1,
    double wF1,
    double rPm1,
    double t1,
    double v2,
    double i2,
    double wF2,
    double rPm2,
    double t2)
    : AggregateRootBase<long>
{
    public long MachineId { get; private set; } = machineId;
    public DateTime Time { get; private set; } = time;
    public double V1 { get; private set; } = v1;
    public double I1 { get; private set; } = i1;
    public double WF1 { get; private set; } = wF1;
    public double RPM1 { get; private set; } = rPm1;
    public double T1 { get; private set; } = t1;
    public double V2 { get; private set; } = v2;
    public double I2 { get; private set; } = i2;
    public double WF2 { get; private set; } = wF2;
    public double RPM2 { get; private set; } = rPm2;
    public double T2 { get; private set; } = t2;
}
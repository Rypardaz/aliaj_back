using PhoenixFramework.Domain;

namespace AM.Domain.MachineLogAgg;

public class MachineLog : AggregateRootBase<long>
{
    public MachineLog(long machineId,
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
    {
        MachineId = machineId;
        Time = time;
        V1 = v1;
        I1 = i1;
        WF1 = wF1;
        RPM1 = rPm1;
        T1 = t1;
        V2 = v2;
        I2 = i2;
        WF2 = wF2;
        RPM2 = rPm2;
        T2 = t2;
    }

    protected MachineLog()
    {
    }

    public long MachineId { get; private set; }
    public DateTime Time { get; private set; }
    public double V1 { get; private set; }
    public double I1 { get; private set; }
    public double WF1 { get; private set; }
    public double RPM1 { get; private set; }
    public double T1 { get; private set; }
    public double V2 { get; private set; }
    public double I2 { get; private set; }
    public double WF2 { get; private set; }
    public double RPM2 { get; private set; }
    public double T2 { get; private set; }
}
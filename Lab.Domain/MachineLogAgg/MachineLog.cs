using PhoenixFramework.Domain;

namespace Ex.Domain.MachineLogAgg
{
    public class MachineLog : AggregateRootBase<long>
    {
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

        public MachineLog(long machineId, DateTime time, double v1, double i1, double wF1, double rPM1, double t1, double v2, double i2, double wF2, double rPM2, double t2)
        {
            MachineId = machineId;
            Time = time;
            V1 = v1;
            I1 = i1;
            WF1 = wF1;
            RPM1 = rPM1;
            T1 = t1;
            V2 = v2;
            I2 = i2;
            WF2 = wF2;
            RPM2 = rPM2;
            T2 = t2;
        }
    }
}
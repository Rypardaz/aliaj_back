using PhoenixFramework.Application.Command;

namespace Ex.Application.Contracts.MachineLog
{
    public class CreateMachineLog : ICommand
    {
        public string DL { get; set; }
        public DateTime Time { get; set; }
        public double V1 { get; set; }
        public double I1 { get; set; }
        public double WF1 { get; set; }
        public double RPM1 { get; set; }
        public double T1 { get; set; }
        public double V2 { get; set; }
        public double I2 { get; set; }
        public double WF2 { get; set; }
        public double RPM2 { get; set; }
        public double T2 { get; set; }
    }
}

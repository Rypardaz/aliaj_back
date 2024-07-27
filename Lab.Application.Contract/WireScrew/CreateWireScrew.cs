using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.WireScrew
{
    public class CreateWireScrew : ICommand
    {
        [Required]
        public Guid WireTypeGuid { get; set; }
        [Required]
        public required int Screw { get; set; }
        [Required]
        public decimal Qty{ get; set; }
    }

}

using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.Salon
{
    public class CreateSalon : ICommand
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Code { get; set; }
        [Required]
        public required Guid TypeGuid { get; set; }
        [Required]
        public required bool HasGas { get; set; }
        [Required]
        public required bool HasWire { get; set; }
        [Required]
        public required bool HasWireScrew { get; set; }
        [Required]
        public required bool HasPowder { get; set; }
    }
}

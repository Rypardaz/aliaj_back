using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.Machine
{
    public class CreateMachine : ICommand
    {
        [Required]
        public required string Code { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public Guid SalonGuid { get; set; }
        [Required]
        public required byte HeadCount { get; set; }
        public string? Description { get; set; }
        public string? Ip { get; set; }
    }
}

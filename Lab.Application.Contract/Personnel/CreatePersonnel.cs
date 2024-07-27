using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.Personnel
{
    public class CreatePersonnel : ICommand
    {
        [Required]
        public required string Code { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Family { get; set; }
        public Guid SalonGuid { get; set; }
    }
}

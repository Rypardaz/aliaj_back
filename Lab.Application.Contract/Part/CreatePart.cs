using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace Ex.Application.Contracts.Part
{
    public class CreatePart : ICommand
    {
        [Required]
        public Guid PartGroupGuid { get; set; }
        [Required]
        public required string Name { get; set; }
        public decimal? StandardWireConsumption { get; set; }
    }
}

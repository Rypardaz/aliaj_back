using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.Part;

public class CreatePart : ICommand
{
    [Required]
    public Guid PartGroupGuid { get; set; }
    [Required]
    public required string Name { get; set; }
    public decimal? StandardWireConsumption { get; set; }
}
using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace AM.Application.Contracts.Material;

public class CreateMaterial : ICommand
{
    [Required]
    public required string Code { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required Guid UnitGuid { get; set; }
}

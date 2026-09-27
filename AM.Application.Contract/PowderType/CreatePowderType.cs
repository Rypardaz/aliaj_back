using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PowderType;

public class CreatePowderType : ICommand
{
    [Required]
    public Guid PowderTypeGroupGuid { get; set; }
    [Required]
    public required string Name { get; set; }
}
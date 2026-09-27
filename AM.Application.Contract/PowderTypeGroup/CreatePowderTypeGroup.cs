using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PowderTypeGroup;

public class CreatePowderTypeGroup : ICommand
{
    [Required]
    public required string Name { get; set; }
}
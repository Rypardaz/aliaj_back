
using PhoenixFramework.Application.Command;
using System.ComponentModel.DataAnnotations;

namespace AM.Application.Contracts.Unit;

public class CreateUnit : ICommand
{
    [Required]
    public required string Code { get; set; }
    [Required]
    public required string Name { get; set; }
}

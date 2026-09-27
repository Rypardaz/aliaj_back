using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.GasTypeGroup;

public class CreateGasTypeGroup : ICommand
{
    [Required]
    public required string Name { get; set; }
}
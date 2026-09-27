using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.GasType;

public class CreateGasType : ICommand
{
    [Required]
    public Guid GasTypeGroupGuid { get; set; }
    [Required]
    public required string Name { get; set; }
}
using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireTypeGroup;

public class CreateWireTypeGroup : ICommand
{
    [Required]
    public required string Name { get; set; }
}
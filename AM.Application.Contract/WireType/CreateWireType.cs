using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.WireType;

public class CreateWireType : ICommand
{
    [Required]
    public Guid WireTypeGroupGuid { get; set; }
    public string Code { get; set; }
    [Required]
    public required string Name { get; set; }

    public decimal? WireSize { get; set; }
}
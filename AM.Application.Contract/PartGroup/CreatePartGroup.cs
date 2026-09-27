using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.PartGroup;

public class CreatePartGroup : ICommand
{
    [Required]
    public required string Name { get; set; }

    public Guid SalonGuid { get; set; }
}
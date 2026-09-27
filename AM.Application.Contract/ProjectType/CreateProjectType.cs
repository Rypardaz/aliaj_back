using System.ComponentModel.DataAnnotations;
using PhoenixFramework.Application.Command;

namespace AM.Application.Contracts.ProjectType;

public class CreateProjectType : ICommand
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public Guid SalonGuid { get; set; }
}